using OpenQA.Selenium;

namespace FileDownloadBot.Models
{
    public class DownloadFile
    {
        public string Url { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string SizeLabel { get; set; } = string.Empty;
    }

}
