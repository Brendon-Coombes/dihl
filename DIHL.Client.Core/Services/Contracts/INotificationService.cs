using System;
using DIHL.Client.Core.Enums;

namespace DIHL.Client.Core.Services.Contracts
{
	public interface INotificationService
	{
		event EventHandler<Notification> NotificationShouldDisplay;

		void Display(string message, Severity severity);
	}
}
