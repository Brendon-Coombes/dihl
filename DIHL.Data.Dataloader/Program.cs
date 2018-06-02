using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DIHL.Data.Dataloader.Facade;
using DIHL.Data.Dataloader.Page;
using DIHL.Repository.Sql.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

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

            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver("..\\..\\..\\Tools");
            //driver.Test("https://www.mystatsonline.com/hockey/visitor/league/home/home_hockey.aspx?IDLeague=7155");

            //ScheduleAndScoresPage page = new ScheduleAndScoresPage(driver, Season.WinterDIHL2016);
            //page.Navigate();
            //var gameIds = page.GetGameIds();

            GamePage gamePage = new GamePage(driver, "251457");
            gamePage.Navigate();
            var info = gamePage.RetrieveGameDetails();

            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacModule>();
            builder.Populate(services);
            var applicationContainer = builder.Build();
            var serviceProvider = new AutofacServiceProvider(applicationContainer);

            IServiceFacade serviceFacade = serviceProvider.GetService<IServiceFacade>();
            serviceFacade.SaveGameInformation(info).GetAwaiter().GetResult();
        }
    }
}
