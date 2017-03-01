namespace YoutubeDowloader
{
    public class DownloadItemSettings
    {
        public string Url { get; set; }
        public string SaveToPath { get; set; }
        public bool OverrideExisting { get; set; }
        public int MaxResolution { get; set; }
    }
}
