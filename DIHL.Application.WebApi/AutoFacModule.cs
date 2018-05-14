using Autofac;
using Autofac.Core;
using DIHL.Application.Core.Services;
using DIHL.Application.Core.Utilities;
using DIHL.Repository.Sql.Repositories;
using System.Reflection;
using DIHL.Application.WebApi.Telemetry;

namespace DIHL.Application.WebApi
{
    internal class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var coreAssembly = Assembly.GetAssembly(typeof(ServiceBase));
            builder.RegisterAssemblyTypes(coreAssembly)
                .Where(_ => _.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(coreAssembly)
                .Where(_ => _.Name.EndsWith("Handler"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(coreAssembly)
                .Where(_ => _.Name.EndsWith("Mapper"))
                .AsSelf()
                .SingleInstance();
            builder.RegisterAssemblyTypes(coreAssembly)
                .Where(_ => _.Name.EndsWith("Factory"))
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<ConnectedServiceActionHandler>()
                .WithParameter("serviceName", "SQL")
                .As<IActionHandler>()
                .Keyed<IActionHandler>("SQL")
                .SingleInstance();

            builder.RegisterType<CoreActionHandler>()
                .As<IActionHandler>()
                .SingleInstance();

            builder.RegisterType<LeagueRepository>()
                .AsImplementedInterfaces()
                .WithParameter(new ResolvedParameter(
                       (pi, ctx) => pi.ParameterType == typeof(IActionHandler),
                       (pi, ctx) => ctx.ResolveKeyed<IActionHandler>("SQL")));

            builder.RegisterType<SeasonRepository>()
                .AsImplementedInterfaces()
                .WithParameter(new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IActionHandler),
                    (pi, ctx) => ctx.ResolveKeyed<IActionHandler>("SQL")));

            builder.RegisterType<PlayerRepository>()
                .AsImplementedInterfaces()
                .WithParameter(new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IActionHandler),
                    (pi, ctx) => ctx.ResolveKeyed<IActionHandler>("SQL")));

            builder.RegisterType<SettingsRepository>()
		        .AsImplementedInterfaces()
		        .WithParameter(new ResolvedParameter(
			        (pi, ctx) => pi.ParameterType == typeof(IActionHandler),
			        (pi, ctx) => ctx.ResolveKeyed<IActionHandler>("SQL")));

			var sqlAssembly = Assembly.GetAssembly(typeof(LeagueRepository));
            builder.RegisterAssemblyTypes(sqlAssembly)
                .Where(_ => _.Name.EndsWith("Mapper"))
                .AsImplementedInterfaces();

            builder.RegisterType<AppInsightsTelemetryClientWrapper>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
