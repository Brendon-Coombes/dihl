using DIHL.Client.Core.ViewModels.Base;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace DIHL.Client.Core.ViewModels.DemoPage
{
	public class ModalViewModel : BaseViewModelResult<bool>
	{
		private readonly IMvxNavigationService _navigationService;

		public IMvxCommand CloseCommand => new MvxCommand(Close);
		public IMvxCommand CloseAndSaveCommand => new MvxCommand(CloseAndSave);

		public ModalViewModel(IMvxNavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		private void Close()
		{
			_navigationService.Close(this, false);
		}

		private void CloseAndSave()
		{
			// Execute(); - save changes
			_navigationService.Close(this, true);
		}
	}
}
