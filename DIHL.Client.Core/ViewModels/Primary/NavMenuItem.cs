using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DIHL.Client.Core.ViewModels.Primary
{
	public class NavMenuItem : INotifyPropertyChanged
	{
		private bool _isSelected;
		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				if (_isSelected == value) return;
			    _isSelected = value;
			    OnPropertyChanged();
			}
		}

	    public Type ViewModelType { get; }
        public string Label { get; }
		public string Icon { get; }

		public NavMenuItem(Type viewModelType, string label, string icon)
		{
		    ViewModelType = viewModelType;
            Label = label;
			Icon = icon;
		}

	    public event PropertyChangedEventHandler PropertyChanged;
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
	        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
	}
}
