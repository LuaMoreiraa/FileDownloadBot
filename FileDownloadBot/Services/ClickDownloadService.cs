using OpenQA.Selenium;
using FileDownloadBot.Models;

namespace FileDownloadBot.Services
{
    public class ClickDownloadService
    {
        private readonly IWebDriver _driver;

        public ClickDownloadService(IWebDriver driver)
        {
            _driver = driver;
        }

        public void DownloaddByClick(List<DownloadFile> files)
        {
            foreach (var file in files)
            {
                var link = _driver.FindElements(By.TagName("a")).FirstOrDefault(a => a.GetAttribute("href")?.Contains(file.FileName) == true);
                link?.Click();
                Thread.Sleep(1000);
            }
        }
    }
}