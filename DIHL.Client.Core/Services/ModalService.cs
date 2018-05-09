using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DIHL.Client.Core.Enums;
using DIHL.Client.Core.Services.Contracts;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace DIHL.Client.Core.Services
{
	public class ModalService : IModalService
	{
	    private static readonly MvxBundle Bundle = new MvxBundle(new Dictionary<string, string>
	    {
	        {"Region", "PopupContent"},
	        {"Significance", Significance.Minor.ToString()}
	    });

        private readonly IMvxNavigationService _navigationService;

        private bool _isPopupOpen;
		public bool IsPopupOpen
		{
			get => _isPopupOpen;
			set
			{
				if (_isPopupOpen == value) return;
				_isPopupOpen = value;
				OnPropertyChanged();
			}
		}

		public ModalService(IMvxNavigationService navigationService)
		{
			_navigationService = navigationService;
        }

		public async Task<TResult> Display<TViewModel, TResult>() where TViewModel : IMvxViewModelResult<TResult>
		{
			IsPopupOpen = true;
			var result = await _navigationService.Navigate<TViewModel, TResult>(Bundle);
		    IsPopupOpen = false;
		    return result;
        }

		public async Task<TResult> Display<TViewModel, TParameter, TResult>(TParameter parameter) where TViewModel : IMvxViewModel<TParameter, TResult>
		{
			IsPopupOpen = true;
			var result = await _navigationService.Navigate<TViewModel, TParameter, TResult>(parameter, Bundle);
		    IsPopupOpen = false;
		    return result;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
