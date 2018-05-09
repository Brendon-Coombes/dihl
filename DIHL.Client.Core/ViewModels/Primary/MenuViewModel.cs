using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Client.Core.Enums;
using DIHL.Client.Core.Services.Contracts;
using DIHL.Client.Core.ViewModels.Base;
using DIHL.Client.Core.ViewModels.DemoPage;
using DIHL.Client.Core.ViewModels.OtherPage;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace DIHL.Client.Core.ViewModels.Primary
{
	public class MenuViewModel : BaseViewModel
	{
	    private static readonly IMvxBundle Bundle = new MvxBundle(new Dictionary<string, string>
	    {
	        {"Significance", Significance.Major.ToString()}
	    });

        private readonly IMvxNavigationService _navigationService;
	    private readonly IMenuService _menuService;

        private Type _page;
		public Type Page
		{
			get => _page;
			set
			{
				if (_page == value) return;
			    _page = value;
			    _navigationService.Navigate(value, Bundle);
                UpdateSelection();
			}
		}

		public IList<NavMenuItem> MenuItems { get; set; }

		public IMvxCommand MenuItemClick => new MvxCommand<Type>(viewModelType => Page = viewModelType);

		public MenuViewModel(IMvxNavigationService navigationService, IMenuService menuService)
		{
			_navigationService = navigationService;
		    _menuService = menuService;
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			MenuItems = new List<NavMenuItem>
			{
				new NavMenuItem(typeof(DemoPageViewModel), Common.GetText("DemoPage"), "DemoPageMenuIcon"),
				new NavMenuItem(typeof(OtherPageViewModel), Common.GetText("OtherPage"), "OtherPageMenuIcon")
			};

		    _menuService.SelectionChanged += (sender, args) =>
		    {
		        _page = args.NewPage;
		        UpdateSelection();
		    };
		}

		public override void ViewAppeared()
		{
			base.ViewAppeared();
			Page = MenuItems.First().ViewModelType;
		}

	    private void UpdateSelection()
	    {
	        foreach (var menuItem in MenuItems)
	            menuItem.IsSelected = Page == menuItem.ViewModelType;
        }
	}
}
