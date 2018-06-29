using System;
using Microsoft.Extensions.Configuration;

namespace DIHL.Repository.Sql.Startup
{
    internal class Program
    {
        private static IConfigurationRoot Configuration;

        private static void Main(string[] args)
        {
            Console.WriteLine("This is a bare bones console app purely to act as the startup project when running Entity Framework commands through dotnet independently of web app dependencies.");
            Console.WriteLine("Check out README.MD for more info.");
            Console.ReadKey();
        }
    }
}
