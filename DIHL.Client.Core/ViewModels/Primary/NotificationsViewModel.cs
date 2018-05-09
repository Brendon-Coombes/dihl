using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Client.Core.Enums;
using DIHL.Client.Core.Services;
using DIHL.Client.Core.Services.Contracts;
using DIHL.Client.Core.Util;
using DIHL.Client.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;

namespace DIHL.Client.Core.ViewModels.Primary
{
	public class NotificationsViewModel : BaseViewModel
	{
		private static readonly Dictionary<Severity, TimeSpan> NotificationLifeTimes = new Dictionary<Severity, TimeSpan>
		{
			{Severity.Notice, TimeSpan.FromSeconds(3)},
			{Severity.Warning, TimeSpan.FromSeconds(5)},
			{Severity.Error, TimeSpan.MaxValue}
		};

		private readonly INotificationService _notificationService;

		public TransientRestrictedObservableQueue<Notification> Notifications { get; set; }

		public IMvxCommand<Notification> DismissNotification => new MvxCommand<Notification>(notification => Notifications.Remove(notification));

		public NotificationsViewModel(INotificationService notificationService)
		{
			_notificationService = notificationService;

			Notifications = new TransientRestrictedObservableQueue<Notification>(3);
		}

		public override async Task Initialize()
		{
			await base.Initialize();
			_notificationService.NotificationShouldDisplay += Notify;
		}

		private void Notify(object sender, Notification notification)
		{
			Notifications.Enqueue(notification, NotificationLifeTimes[notification.Severity]);
		}
	}
}
