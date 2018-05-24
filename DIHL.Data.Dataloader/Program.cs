using System;
using DIHL.Data.Dataloader.WebDriver;

namespace DIHL.Data.Dataloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Dataloader");
            ChromeDriver driver = new ChromeDriver();
            driver.Test("https://www.mystatsonline.com/hockey/visitor/league/home/home_hockey.aspx?IDLeague=7155");
        }

    }
}
