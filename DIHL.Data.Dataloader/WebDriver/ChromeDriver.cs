using System;
using DIHL.Data.Dataloader.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public void Test(string url)
        {
            _driver.Url = url;
            _driver.WaitUntilElementClickable(By.Id("maincontent_msoGvStandings_rptStandings_gvStandings_0_wrapper"));
            IWebElement element = _driver.FindElement(By.Id("maintitle_ddlSeason"));
            element.Click();
            element.SendKeys(Keys.Down);
            element.SendKeys(Keys.Down);
            element.SendKeys(Keys.Enter);
        }

        public void Dispose()
        {
            _driver.Close();
            _driver?.Dispose();
        }        
    }
}
