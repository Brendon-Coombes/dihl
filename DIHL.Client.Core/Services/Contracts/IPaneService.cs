using System.ComponentModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace DIHL.Client.Core.Services.Contracts
{
	public interface IPaneService : INotifyPropertyChanged
	{
		bool IsPaneOpen { get; set; }

		Task<TResult> Display<TViewModel, TResult>() where TViewModel : IMvxViewModelResult<TResult>;

		Task<TResult> Display<TViewModel, TParameter, TResult>(TParameter parameter) where TViewModel : IMvxViewModel<TParameter, TResult>;
	}
}
