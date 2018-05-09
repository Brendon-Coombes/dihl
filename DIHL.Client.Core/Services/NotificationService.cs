using System;
using DIHL.Client.Core.Enums;
using DIHL.Client.Core.Services.Contracts;

namespace DIHL.Client.Core.Services
{
	public class NotificationService : INotificationService
	{
		public event EventHandler<Notification> NotificationShouldDisplay;

		public void Display(string message, Severity severity)
		{
			var notification = new Notification(message, severity);
			NotificationShouldDisplay?.Invoke(this, notification);
		}
	}

	public class Notification
	{
		public string Message { get; }
		public Severity Severity { get; }

		public Notification(string message, Severity severity)
		{
			Message = message;
			Severity = severity;
		}
	}
}
