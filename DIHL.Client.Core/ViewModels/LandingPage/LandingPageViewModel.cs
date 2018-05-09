using System;
using System.Threading.Tasks;
using DIHL.Client.Core.Services.Contracts;
using DIHL.Client.Core.ViewModels.Base;
using DIHL.Client.Core.ViewModels.Primary;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Serilog;

namespace DIHL.Client.Core.ViewModels.LandingPage
{
    public class LandingPageViewModel : BaseViewModel
    {
        private readonly ILogger _logger = Log.ForContext<LandingPageViewModel>();
        private readonly IMvxNavigationService _navigationService;
        private readonly INotificationService _notificationService;

        private bool _extendedSplashScreenVisible = true;
        public bool ExtendedSplashScreenVisible
        {
            get => _extendedSplashScreenVisible;
            set => SetProperty(ref _extendedSplashScreenVisible, value);
        }

        public IMvxCommand GoToPrimaryView => new MvxCommand(LoadUserSpecific);

        public LandingPageViewModel(IMvxNavigationService navigationService, INotificationService notificationService)
        {
            _navigationService = navigationService;
            _notificationService = notificationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            await LoadUserAmbiguous();
            ExtendedSplashScreenVisible = false;
        }

        private async Task LoadUserAmbiguous()
        {
            // load anything ambiguous of the user you might want
            await Common.Execute(_notificationService, _logger, "load user ambiguous data", async () => await Task.Delay(TimeSpan.FromSeconds(1)), false);
        }

        private async void LoadUserSpecific()
        {
            // login / authenticate
            // do anything else you might want
            await Common.Execute(_notificationService, _logger, "load user specific data", async () => await Task.Delay(TimeSpan.FromSeconds(0.5)));
            await _navigationService.Navigate<MainViewModel>();
        }
    }
}
