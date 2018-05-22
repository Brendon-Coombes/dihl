using System;
using OpenQA.Selenium;
namespace DIHL.Data.Dataloader.WebDriver
{
    public class ChromeDriver : IDisposable
    {
        private readonly IWebDriver _driver;

        public ChromeDriver()
        {
            //ChromeDriver can be installed via PATH and the physical path does not need to be specified.
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver("..\\..\\..\\Tools");
        }

        public void Browse(string url)
        {
            _driver.Url = url;
        }

        public void Dispose()
        {
            _driver.Close();
            _driver?.Dispose();
        }
    }
}
