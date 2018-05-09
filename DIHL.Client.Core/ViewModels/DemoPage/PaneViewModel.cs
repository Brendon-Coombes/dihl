using DIHL.Client.Core.Domain;
using DIHL.Client.Core.ViewModels.Base;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace DIHL.Client.Core.ViewModels.DemoPage
{
	public class PaneViewModel : BaseViewModel<ChristmasPresent, bool>
	{
		private readonly IMvxNavigationService _navigationService;

		public string Name { get; private set; }
		public string From { get; private set; }
		public string To { get; private set; }
		public string Image { get; private set; }

		public IMvxCommand CloseCommand => new MvxCommand(() => _navigationService.Close(this, false));

		public PaneViewModel(IMvxNavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public override void Prepare(ChristmasPresent parameter)
		{
			Name = parameter.Name;
			From = parameter.From;
			To = parameter.To;
			Image = parameter.Image;
		}
	}
}
