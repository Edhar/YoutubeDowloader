using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace YoutubeDowloader
{
    public static class Utils
    {
        public static string RemoveIllegalPathCharacters(this string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return string.Empty;
            }

            var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex($"[{Regex.Escape(regexSearch)}]");
            return r.Replace(path, "");
        }

        public static bool ChannelMode(this string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }
            var path = new Uri(url).AbsolutePath;
            return path.Contains("user") || path.Contains("channel");
        }

        public static bool ListMode(this string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            return new Uri(url).Query.Contains("list");
        }

        public static HtmlDocument GetHtmlDocument(this string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    if (webResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var stream = webResponse.GetResponseStream();
                        var doc = new HtmlDocument
                        {
                            OptionFixNestedTags = true
                        };
                        doc.Load(stream, true);
                        return doc;
                    }
                }
            }

            return null;
        }
        public static string ExtractHtml(this HtmlDocument document, string xpath, bool outerHtmlElseInner = true)
        {
            var htmlNode = document?.DocumentNode.SelectSingleNode(xpath);
            if (htmlNode != null)
            {
                return outerHtmlElseInner ? htmlNode.OuterHtml : htmlNode.InnerHtml;
            }
            return string.Empty;
        }

        public static List<string> GetChannelItemsUrls(this string youtubeChannelUrl)
        {
            var results = new List<string>();
            
            var document = youtubeChannelUrl.GetHtmlDocument();
            var chanelNode = document?.DocumentNode.SelectSingleNode("//div[@class=\"primary-header-actions\"]//button[@data-channel-external-id][1]");
            var anyVideoIdNode = document?.DocumentNode.SelectSingleNode("(//a[starts-with(@href, \"/watch?v=\")])[1]");
            if (chanelNode != null && anyVideoIdNode != null)
            {
                var channelId = chanelNode.Attributes["data-channel-external-id"].Value;
                var channelPlayListId = "UU" + channelId.Substring(2);
                var anyVideoId = HttpUtility.ParseQueryString(new Uri("https://www.youtube.com" +  anyVideoIdNode.Attributes["href"].Value).Query)["v"];
                var youtubePlaylistUrl = string.Format("https://www.youtube.com/watch?v={0}&list={1}", anyVideoId,
                    channelPlayListId);
                return youtubePlaylistUrl.GetPlaylistItemsUrls();
            }

            return results;
        }

        public static List<string> GetPlaylistItemsUrls(this string youtubePlaylistUrl)
        {
            var results = new Dictionary<string, int>();
            var minId = 0;
            var maxId = 0;
            if (!string.IsNullOrWhiteSpace(youtubePlaylistUrl))
            {
                var listId = HttpUtility.ParseQueryString(new Uri(youtubePlaylistUrl).Query)["list"];
                bool findNewItems = true;
                do
                {
                    try
                    {
                        HtmlDocument document;
                        if (maxId == 0)
                        {
                            document = youtubePlaylistUrl.GetHtmlDocument();
                        }
                        else
                        {
                            if (findNewItems)
                            {
                                var last = results.FirstOrDefault(i => i.Value == maxId);
                                document =
                                    $"https://www.youtube.com/watch?v={last.Key}&index={last.Value}&list={listId}"
                                        .GetHtmlDocument();
                            }
                            else if(minId != 1)
                            {
                                var last = results.FirstOrDefault(i => i.Value == minId);
                                document =
                                    $"https://www.youtube.com/watch?v={last.Key}&index={last.Value}&list={listId}"
                                        .GetHtmlDocument();
                            }
                            else
                            {
                                break;
                            }
                        }

                        findNewItems = false;

                        var htmlNodes = document?.DocumentNode.SelectNodes("//a[contains(@class, 'playlist-video')]");
                        if (htmlNodes != null)
                        {
                            var items = htmlNodes.Select(n => "https://www.youtube.com" + HttpUtility.HtmlDecode(n.Attributes["href"].Value)).ToList();
                            foreach (var item in items)
                            {
                                var nvc = HttpUtility.ParseQueryString(new Uri(item).Query);
                                var index = int.Parse(nvc["index"]);
                                var videoId = nvc["v"];
                                if (!results.ContainsKey(videoId))
                                {
                                    if (index > maxId)
                                    {
                                        maxId = index;
                                    }
                                    if (minId == 0 || minId > index)
                                    {
                                        minId = index;
                                    }
                                    findNewItems = true;
                                    results.Add(videoId, index);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        findNewItems = false;
                    }

                } while (findNewItems || minId != 1);
            }
            return results.Select(d => "https://www.youtube.com/watch?v=" + d.Key).ToList();
        }

        public static void DrawText(this ProgressBar progressBar, string text)
        {
            progressBar.Refresh();
            using (Graphics gr = progressBar.CreateGraphics())
            {
                gr.DrawString(text, SystemFonts.DefaultFont, Brushes.Black,
                    new PointF(progressBar.Width / 2 - gr.MeasureString(text, SystemFonts.DefaultFont).Width / 2.0F,
                        progressBar.Height / 2 - gr.MeasureString(text, SystemFonts.DefaultFont).Height / 2.0F));
            }
        }
    }
}
