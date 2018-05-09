using DIHL.Client.Core.ViewModels.Primary;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace DIHL.Client.Core.Application
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;

        public AppStart(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Start(object hint = null)
        {
	        _navigationService.Navigate<MainViewModel>();
        }
    }
}
