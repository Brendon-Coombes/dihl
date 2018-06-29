using System;
using System.Text;
using Autofac;
using DIHL.Application.Identity;
using DIHL.Application.Identity.Models;
using DIHL.Application.WebApi.Config;
using DIHL.Repository.Sql.Database;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.RollingFileAlternate;
using Swashbuckle.AspNetCore.Swagger;

namespace DIHL.Application.WebApi
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<SerilogConfig>(Configuration.GetSection("SerilogConfig"));

            //Add DIHL DB Contect
            services.AddDbContext<DihlDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DIHLDbConnection"));
            });

            //Add Identity specific context
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DIHLDbConnection"));
            });

            //https://github.com/aspnet/Identity/issues/1364
            //Need to inherit IdentityUser/IdentityRole to avoid exception when Id is customised from string
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            services.AddAuthentication()
                .AddJwtBearer(c =>
                {
                    c.RequireHttpsMetadata = true;
                    c.SaveToken = true;
                    c.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DIHL Stats API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<SerilogConfig> serilogConfig, TelemetryClient telemetryClient)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "DIHL API V1");
                s.RoutePrefix = string.Empty;
            });

            ConfigureSerilog(serilogConfig.Value, telemetryClient);

            if (env.IsDevelopment())
            {
                app.UseCors(builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        private void ConfigureSerilog(SerilogConfig serilogConfig, TelemetryClient telemetryClient)
        {
            var logConfig = new LoggerConfiguration()
                .MinimumLevel.Is(serilogConfig.MinimumLevel)
                .Enrich.FromLogContext();

            if (serilogConfig.RollingFile.IsEnabled)
            {
                logConfig.WriteTo.RollingFileAlternate(serilogConfig.RollingFile.Folder, serilogConfig.RollingFile.Level);
            }
            if (serilogConfig.Trace.IsEnabled)
            {
                logConfig.WriteTo.Trace(serilogConfig.Trace.Level);
            }
            if (serilogConfig.AppInsights.IsEnabled)
            {
                logConfig.WriteTo.ApplicationInsightsTraces(telemetryClient, serilogConfig.AppInsights.Level);
            }

            Log.Logger = logConfig.CreateLogger();
            Log.Logger.Information("Logging Initialised");
        }
    }
}
