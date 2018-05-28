using System;
using DIHL.Data.Dataloader.Infrastructure;
using DIHL.Data.Dataloader.Page;
using OpenQA.Selenium;

namespace DIHL.Data.Dataloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Dataloader");
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver("..\\..\\..\\Tools");
            //driver.Test("https://www.mystatsonline.com/hockey/visitor/league/home/home_hockey.aspx?IDLeague=7155");

            ScheduleAndScoresPage page = new ScheduleAndScoresPage(driver, Season.WinterDIHL2016);
            page.Navigate();
            var gameIds = page.GetGameIds();
        }

    }
}
