using DIHL.Client.Core.Application;
using DIHL.Client.Core.ViewModels.LandingPage;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace DIHL.Client.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

	        CreatableTypes()
		        .EndingWith("Manager")
		        .AsInterfaces()
		        .RegisterAsLazySingleton();

			//Mvx.LazyConstructAndRegisterSingleton<IMvxTextProvider>(() => new TextProvider(Strings.ResourceManager));

			RegisterNavigationServiceAppStart<LandingPageViewModel>();
        }
    }
}
