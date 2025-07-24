using OpenQA.Selenium;

namespace FileDownloadBot.Models
{
    public class DownloadFile
    {
        public string Url { get; set; }
        public string FileName { get; set; }
        public string SizeLabel { get; set; }
    }
}
