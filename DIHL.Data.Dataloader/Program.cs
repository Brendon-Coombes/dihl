using System;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DIHL.Data.Dataloader.Facade;
using DIHL.Data.Dataloader.Infrastructure;
using DIHL.Data.Dataloader.Page;
using DIHL.Repository.Sql.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DIHL.Data.Dataloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Dataloader");
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = config.Build();
            var services = new ServiceCollection();
            services.AddDbContext<DihlDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DIHLDbConnection"));
            });
            services.AddAutofac();
            //TODO: pull in from config
            services.AddApplicationInsightsTelemetry("TEST");

            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacModule>();
            builder.Populate(services);
            var applicationContainer = builder.Build();
            var serviceProvider = new AutofacServiceProvider(applicationContainer);

            IServiceFacade serviceFacade = serviceProvider.GetService<IServiceFacade>();
            //TODO: Add this to configuration
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(@"load-extension=C:\Users\BrendonC\AppData\Local\Google\Chrome\User Data\Default\Extensions\gighmmpiobklfepjocnamgkkbiglidom\3.31.2_0");
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver("..\\..\\..\\Tools", chromeOptions);

            ScheduleAndScoresPage page = new ScheduleAndScoresPage(driver, Season.WinterDIHL2018);
            page.Navigate();

            Console.WriteLine("Retrieving Game Ids...");
            var gameIds = page.GetGameIds();
            
            foreach (var gameId in gameIds)
            {
                GamePage gamePage = new GamePage(driver, gameId);
                gamePage.Navigate();
                var info = gamePage.RetrieveGameDetails();

                serviceFacade.SaveGameInformation(info).GetAwaiter().GetResult();

                Console.WriteLine("Game Saved!");
                Console.WriteLine();
                Console.WriteLine();
            }           
        }
    }
}
