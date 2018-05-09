using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DIHL.Client.Core.Domain;
using DIHL.Client.Core.Enums;
using DIHL.Client.Core.Services.Contracts;
using DIHL.Client.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;
using Serilog;

namespace DIHL.Client.Core.ViewModels.DemoPage
{
    public class DemoPageViewModel : BaseViewModel
    {
        private readonly ILogger _logger = Log.ForContext<DemoPageViewModel>();
        private readonly IGenericListService _presentsService;
        private readonly INotificationService _notificationService;
        private readonly IDialogService _dialogService;
        private readonly IPaneService _paneService;
        private readonly IModalService _modalService;

        public IMvxCommand FireNoticeCommand => new MvxCommand(() => ShowNotification(Severity.Notice));
        public IMvxCommand FireWarningCommand => new MvxCommand(() => ShowNotification(Severity.Warning));
        public IMvxCommand FireErrorCommand => new MvxCommand(() => ShowNotification(Severity.Error));
        public IMvxCommand ShowDialogCommand => new MvxCommand(ShowDialog);
        public IMvxCommand ShowModalCommand => new MvxCommand(ShowModal);
        public IMvxCommand<ChristmasPresent> ShowDetailsCommand => new MvxCommand<ChristmasPresent>(ShowDetails);

        public ObservableCollection<ChristmasPresent> Presents { get; set; }

        public DemoPageViewModel(IGenericListService presentsService, INotificationService notificationService, IDialogService dialogService, IModalService modalService, IPaneService paneService)
        {
            _presentsService = presentsService;
            _notificationService = notificationService;
            _dialogService = dialogService;
            _modalService = modalService;
            _paneService = paneService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            Presents = new ObservableCollection<ChristmasPresent>(await _presentsService.GetChristmasPresentsAsync());
        }

        private void ShowNotification(Severity severity)
        {
            string message = null;
            switch (severity)
            {
                case Severity.Notice:
                    message = Common.GetText("NotificationMessage");
                    break;
                case Severity.Warning:
                    message = Common.GetText("WarningMessage");
                    break;
                case Severity.Error:
                    message = Common.GetText("ErrorMessage");
                    break;
            }

            _notificationService.Display(message, severity);
        }

        private async void ShowDialog()
        {
            var userAction = await _dialogService.Display(Common.GetText("DialogTitle"), Common.GetText("DialogMessage"), Common.GetSharedText("Accept"), Common.GetSharedText("Cancel"));
            if (userAction == UserAction.Accepted) await Common.Execute(_notificationService, _logger, "wait for 3 seconds", async () => await Task.Delay(TimeSpan.FromSeconds(3)));
        }

        private async void ShowModal()
        {
            var result = await _modalService.Display<ModalViewModel, bool>();
            if (result) await Common.Execute(_notificationService, _logger, "wait for 3 seconds", async () => await Task.Delay(TimeSpan.FromSeconds(3)));
        }

        private void ShowDetails(ChristmasPresent present)
        {
            _paneService.Display<PaneViewModel, ChristmasPresent, bool>(present);
        }
    }
}
