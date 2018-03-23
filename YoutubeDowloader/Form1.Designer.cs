namespace YoutubeDowloader
{
    partial class YoutubeDowloaderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoutubeDowloaderForm));
			this.SaveToLabel = new System.Windows.Forms.Label();
			this.SaveToChangeButton = new System.Windows.Forms.Button();
			this.SaveToTextBox = new System.Windows.Forms.TextBox();
			this.SaveToFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.OverrideExistingFileCheckBox = new System.Windows.Forms.CheckBox();
			this.MaxQualityComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.AddButton = new System.Windows.Forms.Button();
			this.DownloadFromQueueButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.DowloadButton = new System.Windows.Forms.Button();
			this.YoutubeUrlTextBox = new System.Windows.Forms.TextBox();
			this.LogTextBox = new System.Windows.Forms.TextBox();
			this.DowloadCurrentProgressBar = new System.Windows.Forms.ProgressBar();
			this.DowloadTotalProgressBar = new System.Windows.Forms.ProgressBar();
			this.UrlsListView = new System.Windows.Forms.ListView();
			this.UrlsHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SaveToHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.StatusHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MaxQualityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.OverrideExistingHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ErrorsHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CopyStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.ListContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// SaveToLabel
			// 
			this.SaveToLabel.AutoSize = true;
			this.SaveToLabel.Location = new System.Drawing.Point(6, 16);
			this.SaveToLabel.Name = "SaveToLabel";
			this.SaveToLabel.Size = new System.Drawing.Size(51, 13);
			this.SaveToLabel.TabIndex = 4;
			this.SaveToLabel.Text = "Save To:";
			// 
			// SaveToChangeButton
			// 
			this.SaveToChangeButton.Location = new System.Drawing.Point(578, 13);
			this.SaveToChangeButton.Name = "SaveToChangeButton";
			this.SaveToChangeButton.Size = new System.Drawing.Size(97, 21);
			this.SaveToChangeButton.TabIndex = 5;
			this.SaveToChangeButton.Text = "Choose Folder";
			this.SaveToChangeButton.UseVisualStyleBackColor = true;
			this.SaveToChangeButton.Click += new System.EventHandler(this.SaveToChangeButton_Click);
			// 
			// SaveToTextBox
			// 
			this.SaveToTextBox.Location = new System.Drawing.Point(59, 13);
			this.SaveToTextBox.Name = "SaveToTextBox";
			this.SaveToTextBox.Size = new System.Drawing.Size(517, 20);
			this.SaveToTextBox.TabIndex = 6;
			// 
			// SaveToFolderBrowserDialog
			// 
			this.SaveToFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.OverrideExistingFileCheckBox);
			this.groupBox1.Controls.Add(this.MaxQualityComboBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.SaveToLabel);
			this.groupBox1.Controls.Add(this.SaveToTextBox);
			this.groupBox1.Controls.Add(this.SaveToChangeButton);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1009, 40);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings:";
			// 
			// OverrideExistingFileCheckBox
			// 
			this.OverrideExistingFileCheckBox.AutoSize = true;
			this.OverrideExistingFileCheckBox.Location = new System.Drawing.Point(874, 16);
			this.OverrideExistingFileCheckBox.Name = "OverrideExistingFileCheckBox";
			this.OverrideExistingFileCheckBox.Size = new System.Drawing.Size(124, 17);
			this.OverrideExistingFileCheckBox.TabIndex = 9;
			this.OverrideExistingFileCheckBox.Text = "Override Existing File";
			this.OverrideExistingFileCheckBox.UseVisualStyleBackColor = true;
			// 
			// MaxQualityComboBox
			// 
			this.MaxQualityComboBox.FormattingEnabled = true;
			this.MaxQualityComboBox.Items.AddRange(new object[] {
            "2160",
            "1440",
            "1080",
            "720",
            "480",
            "360"});
			this.MaxQualityComboBox.Location = new System.Drawing.Point(759, 14);
			this.MaxQualityComboBox.Name = "MaxQualityComboBox";
			this.MaxQualityComboBox.Size = new System.Drawing.Size(89, 21);
			this.MaxQualityComboBox.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(688, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Max Quality:";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.groupBox2.Controls.Add(this.AddButton);
			this.groupBox2.Controls.Add(this.DownloadFromQueueButton);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.DowloadButton);
			this.groupBox2.Controls.Add(this.YoutubeUrlTextBox);
			this.groupBox2.Location = new System.Drawing.Point(12, 63);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1009, 44);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(814, 12);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(92, 23);
			this.AddButton.TabIndex = 13;
			this.AddButton.Text = "Add To List";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// DownloadFromQueueButton
			// 
			this.DownloadFromQueueButton.Location = new System.Drawing.Point(912, 12);
			this.DownloadFromQueueButton.Name = "DownloadFromQueueButton";
			this.DownloadFromQueueButton.Size = new System.Drawing.Size(91, 23);
			this.DownloadFromQueueButton.TabIndex = 14;
			this.DownloadFromQueueButton.Text = "Download List";
			this.DownloadFromQueueButton.UseVisualStyleBackColor = true;
			this.DownloadFromQueueButton.Click += new System.EventHandler(this.DownloadFromQueueButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Video/Playlist/Channel Url:";
			// 
			// DowloadButton
			// 
			this.DowloadButton.Location = new System.Drawing.Point(705, 12);
			this.DowloadButton.Name = "DowloadButton";
			this.DowloadButton.Size = new System.Drawing.Size(89, 23);
			this.DowloadButton.TabIndex = 12;
			this.DowloadButton.Text = "Download";
			this.DowloadButton.UseVisualStyleBackColor = true;
			this.DowloadButton.Click += new System.EventHandler(this.DowloadButton_Click);
			// 
			// YoutubeUrlTextBox
			// 
			this.YoutubeUrlTextBox.Location = new System.Drawing.Point(147, 13);
			this.YoutubeUrlTextBox.Name = "YoutubeUrlTextBox";
			this.YoutubeUrlTextBox.Size = new System.Drawing.Size(552, 20);
			this.YoutubeUrlTextBox.TabIndex = 11;
			// 
			// LogTextBox
			// 
			this.LogTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.LogTextBox.Location = new System.Drawing.Point(11, 165);
			this.LogTextBox.Multiline = true;
			this.LogTextBox.Name = "LogTextBox";
			this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.LogTextBox.Size = new System.Drawing.Size(1009, 92);
			this.LogTextBox.TabIndex = 16;
			// 
			// DowloadCurrentProgressBar
			// 
			this.DowloadCurrentProgressBar.Location = new System.Drawing.Point(11, 133);
			this.DowloadCurrentProgressBar.Name = "DowloadCurrentProgressBar";
			this.DowloadCurrentProgressBar.Size = new System.Drawing.Size(1009, 24);
			this.DowloadCurrentProgressBar.TabIndex = 15;
			// 
			// DowloadTotalProgressBar
			// 
			this.DowloadTotalProgressBar.Location = new System.Drawing.Point(12, 113);
			this.DowloadTotalProgressBar.Name = "DowloadTotalProgressBar";
			this.DowloadTotalProgressBar.Size = new System.Drawing.Size(1009, 14);
			this.DowloadTotalProgressBar.TabIndex = 14;
			// 
			// UrlsListView
			// 
			this.UrlsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UrlsHeader,
            this.SaveToHeader,
            this.StatusHeader,
            this.MaxQualityHeader,
            this.OverrideExistingHeader,
            this.ErrorsHeader});
			this.UrlsListView.GridLines = true;
			this.UrlsListView.Location = new System.Drawing.Point(11, 263);
			this.UrlsListView.Name = "UrlsListView";
			this.UrlsListView.ShowItemToolTips = true;
			this.UrlsListView.Size = new System.Drawing.Size(1010, 167);
			this.UrlsListView.TabIndex = 12;
			this.UrlsListView.UseCompatibleStateImageBehavior = false;
			this.UrlsListView.View = System.Windows.Forms.View.Details;
			this.UrlsListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UrlsListView_MouseUp);
			// 
			// UrlsHeader
			// 
			this.UrlsHeader.Text = "Urls";
			this.UrlsHeader.Width = 373;
			// 
			// SaveToHeader
			// 
			this.SaveToHeader.Text = "Save To";
			this.SaveToHeader.Width = 330;
			// 
			// StatusHeader
			// 
			this.StatusHeader.Text = "Status";
			this.StatusHeader.Width = 76;
			// 
			// MaxQualityHeader
			// 
			this.MaxQualityHeader.Text = "Max Quality";
			this.MaxQualityHeader.Width = 74;
			// 
			// OverrideExistingHeader
			// 
			this.OverrideExistingHeader.Text = "Override Existing";
			this.OverrideExistingHeader.Width = 95;
			// 
			// ErrorsHeader
			// 
			this.ErrorsHeader.Text = "Errors";
			this.ErrorsHeader.Width = 594;
			// 
			// ListContextMenuStrip
			// 
			this.ListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyStripMenuItem,
            this.RemoveStripMenuItem});
			this.ListContextMenuStrip.Name = "ListContextMenuStrip";
			this.ListContextMenuStrip.Size = new System.Drawing.Size(180, 48);
			this.ListContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ListContextMenuStrip_ItemClicked);
			// 
			// CopyStripMenuItem
			// 
			this.CopyStripMenuItem.Name = "CopyStripMenuItem";
			this.CopyStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.CopyStripMenuItem.Text = "Copy Column Value";
			this.CopyStripMenuItem.Visible = false;
			// 
			// RemoveStripMenuItem
			// 
			this.RemoveStripMenuItem.Name = "RemoveStripMenuItem";
			this.RemoveStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.RemoveStripMenuItem.Text = "Remove";
			// 
			// YoutubeDowloaderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1033, 448);
			this.Controls.Add(this.DowloadCurrentProgressBar);
			this.Controls.Add(this.LogTextBox);
			this.Controls.Add(this.DowloadTotalProgressBar);
			this.Controls.Add(this.UrlsListView);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(822, 403);
			this.Name = "YoutubeDowloaderForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "YoutubeDowloader";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ListContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label SaveToLabel;
        private System.Windows.Forms.Button SaveToChangeButton;
        private System.Windows.Forms.TextBox SaveToTextBox;
        private System.Windows.Forms.FolderBrowserDialog SaveToFolderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox MaxQualityComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox OverrideExistingFileCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar DowloadCurrentProgressBar;
        private System.Windows.Forms.ProgressBar DowloadTotalProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DowloadButton;
        private System.Windows.Forms.TextBox YoutubeUrlTextBox;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.ListView UrlsListView;
        private System.Windows.Forms.ColumnHeader UrlsHeader;
        private System.Windows.Forms.ColumnHeader SaveToHeader;
        private System.Windows.Forms.ColumnHeader StatusHeader;
        private System.Windows.Forms.ColumnHeader MaxQualityHeader;
        private System.Windows.Forms.ColumnHeader OverrideExistingHeader;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DownloadFromQueueButton;
        private System.Windows.Forms.ColumnHeader ErrorsHeader;
        private System.Windows.Forms.ContextMenuStrip ListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CopyStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveStripMenuItem;
    }
}

