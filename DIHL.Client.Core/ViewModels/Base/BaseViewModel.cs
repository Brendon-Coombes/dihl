using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DIHL.Client.Core.Enums;
using DIHL.Client.Core.Services.Contracts;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using Serilog;

namespace DIHL.Client.Core.ViewModels.Base
{
	public class Common : INotifyPropertyChanged
	{
		private static readonly IMvxLanguageBinder SharedTextSource = new MvxLanguageBinder(typeName: "Shared");
		private readonly IMvxLanguageBinder _textSource;

		private bool _isLoading;
		public bool IsLoading
		{
			get => _isLoading;
			set
			{
				if (value == _isLoading) return;
				_isLoading = value;
				OnPropertyChanged();
			}
		}

		internal Common(string typeName)
		{
			_textSource = new MvxLanguageBinder(typeName: typeName);
		}

		public string GetSharedText(string key) => SharedTextSource.GetText(key);
		public string GetText(string key) => _textSource.GetText(key);

        /// <summary>
        /// Executes a given operation.
        /// Handles ViewModel state, exception handling, notifications and logging.
        /// </summary>
        /// <typeparam name="T">Type of object expected to be returned</typeparam>
        /// <param name="notificationService">Notification service</param>
        /// <param name="logger">Logging service</param>
        /// <param name="objective">Description of operation (eg, unabled to: "load data")</param>
        /// <param name="operation">Operation to execute</param>
        /// <param name="displayLoadingIndicator">Whether to lock the UI with a loading wheel</param>
        /// <returns>Result of operation, or default(T)</returns>
        public async Task<T> Execute<T>(INotificationService notificationService, ILogger logger, string objective, Func<Task<T>> operation, bool displayLoadingIndicator = true)
		{
			IsLoading = displayLoadingIndicator;
			try
			{
				logger.Information($"Begin Execution - {objective}");
				return await operation();
			}
			catch (Exception e)
			{
				var message = $"Unable to {objective}{Environment.NewLine}{e.Message}";
				logger.Error(e, message);
				notificationService.Display(message, Severity.Error);
				return default(T);
			}
			finally
			{
				IsLoading = false;
			}
		}

	    /// <summary>
	    /// Executes a given operation.
	    /// Handles ViewModel state, exception handling, notifications and logging.
	    /// </summary>
	    /// <param name="notificationService">Notification service</param>
	    /// <param name="logger">Logging service</param>
	    /// <param name="objective">Description of operation (eg, unabled to: "save data")</param>
	    /// <param name="operation">Operation to execute, no return type</param>
	    /// <param name="displayLoadingIndicator">Whether to lock the UI with a loading wheel</param>
	    /// <returns>Success</returns>
	    public async Task<bool> Execute(INotificationService notificationService, ILogger logger, string objective, Func<Task> operation, bool displayLoadingIndicator = true)
		{
			return await Execute(notificationService, logger, objective, async () => { await operation(); return true; }, displayLoadingIndicator);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public abstract class BaseViewModel : MvxViewModel
	{
		public Common Common { get; }

		protected BaseViewModel()
		{
			Common = new Common(GetType().Name);
		}
	}

	public abstract class BaseViewModel<TParameter> : MvxViewModel<TParameter>
	{
		public Common Common { get; }

		protected BaseViewModel()
		{
			Common = new Common(GetType().Name);
		}
	}

	public abstract class BaseViewModelResult<TResult> : MvxViewModelResult<TResult>
	{
		public Common Common { get; }

		protected BaseViewModelResult()
		{
			Common = new Common(GetType().Name);
		}
	}

	public abstract class BaseViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult>
	{
		public Common Common { get; }

		protected BaseViewModel()
		{
			Common = new Common(GetType().Name);
		}
	}
}
