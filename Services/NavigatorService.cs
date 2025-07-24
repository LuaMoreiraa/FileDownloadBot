using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace FileDownloadBot.Services
{
    public class NavigatorService
    {
        private readonly IWebDriver _driver;

        public NavigatorService()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.default_directory", @"C:\Downloads\Selenium"); 
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            // options.AddArgument(@"user-data-dir=C:\Users\SeuUsuario\AppData\Local\Google\Chrome\User Data");

            _driver = new ChromeDriver(options);
        }

        public void NavigateToTestFilesSite()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var searchBox = wait.Until(d => d.FindElement(By.Name("q")));

            searchBox.SendKeys("Test-Files");
            searchBox.Submit();

            wait.Until(d => d.FindElements(By.CssSelector("a"))
                .Any(e => e.GetAttribute("href")?.Contains("ash-speed.hetzner.com") == true));

            var link = _driver.FindElements(By.CssSelector("a"))
                        .FirstOrDefault(e => e.GetAttribute("href")?.Contains("ash-speed.hetzner.com") == true);
            link?.Click();
        }

        public IWebDriver GetDriver() => _driver;

        public void Quit() => _driver.Quit();
    }
}
