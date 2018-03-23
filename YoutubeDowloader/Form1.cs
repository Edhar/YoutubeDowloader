using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syroot.Windows.IO;
using YoutubeExtractor;

namespace YoutubeDowloader
{
	public partial class YoutubeDowloaderForm : Form
	{
		public YoutubeDowloaderForm()
		{
			InitializeComponent();
			UrlsListView.Controls.Add(_urlsListViewCustomEdit);
			_urlsListViewCustomEdit.Leave += (o, e) =>
			{
				_urlsListViewCustomEdit.Visible = false;
				if (SelectedRowIndex != -1 && SelectedColumnIndex != -1)
				{
					var row = UrlsListView.Items[SelectedRowIndex];
					var column = row.SubItems[SelectedColumnIndex];
					column.Text = _urlsListViewCustomEdit.Text;
				}
			};

			UrlsListView.FullRowSelect = true;

			//SaveToTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			SaveToTextBox.Text = KnownFolders.Downloads.Path;
			MaxQualityComboBox.Items.Clear();
			MaxQualityComboBox.DisplayMember = "Key";
			MaxQualityComboBox.ValueMember = "Value";
			MaxQualityComboBox.DataSource = new BindingSource(GetResolutionList(), null);
			MaxQualityComboBox.SelectedIndex = 2;
		}

		private Dictionary<string, int> GetResolutionList()
		{
			return new Dictionary<string, int>
			{
				{"2160p", 2160},
				{"1440p", 1440},
				{"1080p", 1080},
				{"720p", 720},
				{"480p", 480},
				{"360p", 360},
			};
		}

		private async Task WebClient_DownloadVideo(VideoInfo videoInfo)
		{
			if (videoInfo.RequiresDecryption)
			{
				DownloadUrlResolver.DecryptDownloadUrl(videoInfo);
			}

			var savePath = Path.Combine(SaveToTextBox.Text, videoInfo.Title.RemoveIllegalPathCharacters() + videoInfo.VideoExtension);
			if (File.Exists(savePath))
			{
				if (!OverrideExistingFileCheckBox.Checked)
				{
					return;
				}
				File.Delete(savePath);
			}

			var client = new WebClient();
			client.DownloadProgressChanged += (sender, args) =>
			{
				var progress = (int)(args.BytesReceived / args.TotalBytesToReceive * 100);
				if (progress > DowloadCurrentProgressBar.Value)
				{
					DowloadCurrentProgressBar.Value = progress;
					DowloadCurrentProgressBar.DrawText(videoInfo.Title);
				}
			};
			client.DownloadFileCompleted += (sender, args) =>
			{
				DowloadCurrentProgressBar.Value = 100;
			};


			await client.DownloadFileTaskAsync(new Uri(videoInfo.DownloadUrl), savePath);
		}

		private void DownloadVideo(VideoInfo video, Action<int> downloadProgressChanged)
		{
			if (video.RequiresDecryption)
			{
				DownloadUrlResolver.DecryptDownloadUrl(video);
			}

			var videoDownloader = new VideoDownloader(video,
				Path.Combine(SaveToTextBox.Text, video.Title.RemoveIllegalPathCharacters() + video.VideoExtension));
			videoDownloader.NotOverideExistingFile = !OverrideExistingFileCheckBox.Checked;

			// Register the ProgressChanged event and print the current progress
			var prevValue = 0;
			videoDownloader.DownloadProgressChanged += (sender, args) =>
			{
				if (downloadProgressChanged != null)
				{
					var newValue = (int)args.ProgressPercentage;
					if (newValue > prevValue)
					{
						downloadProgressChanged(newValue);
						prevValue = newValue;
					}
				}
			};
			videoDownloader.Execute();
		}

		private void SaveToChangeButton_Click(object sender, EventArgs e)
		{
			SaveToFolderBrowserDialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
			if (SaveToFolderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				if (!string.IsNullOrEmpty(SaveToFolderBrowserDialog.SelectedPath))
				{
					SaveToTextBox.Text = SaveToFolderBrowserDialog.SelectedPath;
				}
			}
		}

		private void DowloadButton_Click(object sender, EventArgs e)
		{
			var settings = GetCurrentSetting();
			DownloadItem(settings, error =>
			{
				LogTextBox.Text += error;
			});
		}

		private void DownloadItem(DownloadItemSettings settings, Action<string> writeLogOnError)
		{
			LogTextBox.Text = string.Empty;
			var urls = new List<string>();
			if (settings.Url.ChannelMode())
			{
				urls = settings.Url.GetChannelItemsUrls();
			}
			else if (settings.Url.ListMode())
			{
				urls = settings.Url.GetPlaylistItemsUrls();
			}
			else
			{
				urls.Add(settings.Url);
			}

			var maxResolution = ((KeyValuePair<string, int>)MaxQualityComboBox.SelectedItem).Value;

			DowloadTotalProgressBar.Maximum = urls.Count;
			DowloadTotalProgressBar.Value = 0;
			var index = 0;
			foreach (var url in urls)
			{
				++index;
				var count = index + " of " + urls.Count;
				var videoInfos = new List<VideoInfo>();
				try
				{
					videoInfos = DownloadUrlResolver.GetDownloadUrls(url, false)
							.Where(i => i.VideoType == VideoType.Mp4 && i.AudioType != AudioType.Unknown)
							.OrderByDescending(i => i.Resolution).ToList();
					var videoInfo = videoInfos.FirstOrDefault(i => i.Resolution <= maxResolution);
					if (videoInfo != null)
					{
						DowloadTotalProgressBar.Value = index;
						DowloadTotalProgressBar.DrawText(count + " Downloading.");

						DowloadCurrentProgressBar.Value = 0;

						//var task = WebClient_DownloadVideo(videoInfo);
						//task.Wait();

						DownloadVideo(videoInfo, progress =>
						{
							DowloadCurrentProgressBar.Value = progress;
							DowloadCurrentProgressBar.DrawText(videoInfo.Title);
						});

						DowloadCurrentProgressBar.Value = 100;
					}
				}
				catch (Exception ex)
				{
					var error = count + " - " + url;
					if (videoInfos.Any())
					{
						error += " - " + videoInfos.First().Title;
					}
					error += Environment.NewLine;

					error += ex.Message + Environment.NewLine;
					if (ex.Message.Contains("403"))
					{
						error += "Looks this video contains content which is restricted from playback on certain sites or applications.Try to use https://www.clipconverter.cc/" + Environment.NewLine;
					}
					//if (videoInfos.Any())
					//{
					//	foreach (var video in videoInfos)
					//	{
					//		if (video.RequiresDecryption)
					//		{
					//			DownloadUrlResolver.DecryptDownloadUrl(video);
					//		}
					//	}
					//	error += "Possible download urls: " + Environment.NewLine +
					//	         string.Join(Environment.NewLine, videoInfos.Select(v => v.DownloadUrl + v.VideoExtension)) + Environment.NewLine;
					//}
					writeLogOnError?.Invoke(error);
				}
			}
			DowloadTotalProgressBar.Value = DowloadTotalProgressBar.Maximum;
			DowloadTotalProgressBar.DrawText("Download compleated!");
			DowloadTotalProgressBar.Refresh();
		}

		private DownloadItemSettings GetCurrentSetting()
		{
			var downloadItemSettings = new DownloadItemSettings
			{
				Url = YoutubeUrlTextBox.Text,
				SaveToPath = SaveToTextBox.Text,
				OverrideExisting = OverrideExistingFileCheckBox.Checked,
				MaxResolution = ((KeyValuePair<string, int>)MaxQualityComboBox.SelectedItem).Value
			};
			return downloadItemSettings;
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			var downloadItemSettings = GetCurrentSetting();
			var listViewItem = new ListViewItem(downloadItemSettings.Url);
			listViewItem.SubItems.Add(downloadItemSettings.SaveToPath);
			listViewItem.SubItems.Add("In Queue");
			listViewItem.SubItems.Add(downloadItemSettings.MaxResolution.ToString());
			listViewItem.SubItems.Add(downloadItemSettings.OverrideExisting.ToString());
			listViewItem.SubItems.Add("");

			UrlsListView.Items.Add(listViewItem);
			YoutubeUrlTextBox.Text = "";
		}

		private void DownloadFromQueueButton_Click(object sender, EventArgs e)
		{
			LogTextBox.Text = "";
			foreach (ListViewItem item in UrlsListView.Items)
			{
				var settings = new DownloadItemSettings
				{
					Url = item.SubItems[0].Text,
					SaveToPath = item.SubItems[1].Text
				};
				item.SubItems[2].Text = "Downloading";
				settings.MaxResolution = int.Parse(item.SubItems[3].Text);
				settings.OverrideExisting = bool.Parse(item.SubItems[4].Text);

				DownloadItem(settings, error =>
				{
					item.SubItems[5].Text += error;
				});

				item.SubItems[2].Text = "Downloaded";
			}

			foreach (ListViewItem item in UrlsListView.Items)
			{
				var errors = item.SubItems[5].Text;
				if (!string.IsNullOrWhiteSpace(errors))
				{
					item.SubItems[5].Text = "Yes";
					LogTextBox.Text += errors;
				}
				else
				{
					item.SubItems[5].Text = "No";
				}
			}
		}

		private void UrlsListView_MouseUp(object sender, MouseEventArgs e)
		{
			SelectedRowIndex = -1;
			SelectedColumnIndex = -1;
			var info = UrlsListView.HitTest(e.X, e.Y);
			if (info.Item != null)
			{
				SelectedRowIndex = info.Item.Index;
				SelectedColumnIndex = info.Item.SubItems.IndexOf(info.SubItem);

				if (e.Button == MouseButtons.Right)
				{
					ListContextMenuStrip.Show(Cursor.Position);
				}

				if (e.Button == MouseButtons.Left)
				{
					// Raise the DoubleClick event. 
					int now = Environment.TickCount;
					if (now - _previousUrlsListViewClick <= SystemInformation.DoubleClickTime)
					{
						UrlsListViewMouseDoubleClick(sender, e);
					}
					_previousUrlsListViewClick = now;
				}
			}
		}

		private int SelectedRowIndex = -1;
		private int SelectedColumnIndex = -1;

		private void ListContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Name == RemoveStripMenuItem.Name)
			{
				var item = UrlsListView.FocusedItem;
				if (item != null)
				{
					UrlsListView.Items[item.Index].Remove();
				}
			}

			if (e.ClickedItem.Name == CopyStripMenuItem.Name)
			{
				if (SelectedRowIndex != -1 && SelectedColumnIndex != -1)
				{
					var row = UrlsListView.Items[SelectedRowIndex];
					var column = row.SubItems[SelectedColumnIndex];
					Clipboard.SetText(column.Text);
				}
			}
		}
		private readonly TextBox _urlsListViewCustomEdit = new TextBox { BorderStyle = BorderStyle.FixedSingle, Visible = false };

		private int _previousUrlsListViewClick = SystemInformation.DoubleClickTime;

		private void UrlsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListViewHitTestInfo hit = UrlsListView.HitTest(e.Location);

			Rectangle rowBounds = hit.SubItem.Bounds;
			Rectangle labelBounds = hit.Item.GetBounds(ItemBoundsPortion.Label);
			int leftMargin = labelBounds.Left - 1;
			_urlsListViewCustomEdit.Bounds = new Rectangle(rowBounds.Left + leftMargin, rowBounds.Top, UrlsListView.Columns[hit.Item.SubItems.IndexOf(hit.SubItem)].Width - leftMargin - 1, rowBounds.Height - 2);
			_urlsListViewCustomEdit.Text = hit.SubItem.Text;
			_urlsListViewCustomEdit.SelectAll();
			_urlsListViewCustomEdit.Visible = true;
			_urlsListViewCustomEdit.Focus();
		}
	}
}
