using DIHL.Client.Core.Services.Contracts;
using DIHL.Client.Core.ViewModels.Base;
using MvvmCross.Core.Navigation;

namespace DIHL.Client.Core.ViewModels.Primary
{
	public class MainViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService _navigationService;

		public IPaneService PaneService { get; }
		public IModalService ModalService { get; }

		public MainViewModel(IMvxNavigationService navigationService, IPaneService paneService, IModalService modalService)
		{
			_navigationService = navigationService;
			PaneService = paneService;
			ModalService = modalService;
		}

		public override void ViewAppeared()
		{
			_navigationService.Navigate<TitleViewModel>();
			_navigationService.Navigate<NotificationsViewModel>();
			_navigationService.Navigate<MenuViewModel>();
			// MenuViewModel navigates to default page
		}
	}
}
