using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;

namespace FileDownloadBot.Services
{
    public class NavigatorService
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public NavigatorService()
        {
            var downloadDirectory = @"C:\Downloads";
            Directory.CreateDirectory(downloadDirectory);

            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", downloadDirectory);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            options.AddUserProfilePreference("profile.content_settings.exceptions.automatic_downloads.*.setting", 1);

            _driver = new ChromeDriver(options);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateToDownloadPage()
        {
            _driver.Navigate().GoToUrl("https://fsn1-speed.hetzner.com/"); 
            _wait.Until(ExpectedConditions.ElementExists(By.LinkText("100MB.bin")));
        }

        public void DownloadFile(string fileName)
        {
            var link = _wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(fileName)));

            link.Click();

            Console.WriteLine($"Download iniciado: {fileName}");
        }

        public void Quit()
        {
            _driver.Quit();
        }
    }
}
