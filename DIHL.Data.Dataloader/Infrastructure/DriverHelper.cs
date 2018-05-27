using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DIHL.Data.Dataloader.Infrastructure
{
    public static class DriverHelper
    {
        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementClickable(this IWebDriver webDriver, By elementLocator, int timeout = 3)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}
