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
	public class PaneService : IPaneService
	{
	    private static readonly IMvxBundle Bundle = new MvxBundle(new Dictionary<string, string>
	    {
	        {"Region", "PaneContent"},
	        {"Significance", Significance.Minor.ToString()}
	    });

        private readonly IMvxNavigationService _navigationService;
		private readonly IMvxViewModelLoader _viewModelLoader;

		private IMvxViewModel _previousViewModel;

		private bool _isPaneOpen;
		public bool IsPaneOpen
		{
			get => _isPaneOpen;
			set
			{
				if (_isPaneOpen == value) return;
				_isPaneOpen = value;

                // since panes are light-dismiss...
				if (!_isPaneOpen && _previousViewModel != null)
				{
					_navigationService.Close(_previousViewModel);
					_previousViewModel.ViewDestroy();
					_previousViewModel = null;
				}

				OnPropertyChanged();
			}
		}

		public PaneService(IMvxNavigationService navigationService, IMvxViewModelLoader viewModelLoader)
		{
			_navigationService = navigationService;
			_viewModelLoader = viewModelLoader;
        }

		public async Task<TResult> Display<TViewModel, TResult>() where TViewModel : IMvxViewModelResult<TResult>
		{
			IsPaneOpen = true;
		    var request = new MvxViewModelRequest<TViewModel>();
		    _previousViewModel = (TViewModel)_viewModelLoader.LoadViewModel(request, null);
		    var result = await _navigationService.Navigate((TViewModel)_previousViewModel, Bundle);
		    IsPaneOpen = false;
		    return result;
		}

		public async Task<TResult> Display<TViewModel, TParameter, TResult>(TParameter parameter) where TViewModel : IMvxViewModel<TParameter, TResult>
		{
		    IsPaneOpen = true;
		    var request = new MvxViewModelRequest<TViewModel>();
		    _previousViewModel = (TViewModel)_viewModelLoader.LoadViewModel(request, null);
		    var result = await _navigationService.Navigate((TViewModel)_previousViewModel, parameter, Bundle);
		    IsPaneOpen = false;
		    return result;
        }

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
