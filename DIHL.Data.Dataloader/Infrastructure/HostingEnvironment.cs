using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

//NOTE: This is required by Application Insights even though it doens't really fit with a console app.

namespace DIHL.Data.Dataloader.Infrastructure
{
    public class HostingEnvironment : IHostingEnvironment
    {
        public string EnvironmentName { get; set; }
        public string ApplicationName { get; set; }
        public string WebRootPath { get; set; }
        public IFileProvider WebRootFileProvider { get; set; }
        public string ContentRootPath { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }

        public HostingEnvironment()
        {
            EnvironmentName = "Dev";
            ApplicationName = "DIHL.Data.Dataloader";
        }
    }
}
