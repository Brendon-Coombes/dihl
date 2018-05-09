using System;
using DIHL.Client.Core.Services.Contracts;

namespace DIHL.Client.Core.Services
{
    public class MenuService : IMenuService
    {
        public event EventHandler<MenuSelectionChangedEventArgs> SelectionChanged;

        public void RaiseSelectionChanged(Type newPage)
        {
            var args = new MenuSelectionChangedEventArgs(newPage);
            SelectionChanged?.Invoke(this, args);
        }
    }

    public class MenuSelectionChangedEventArgs : EventArgs
    {
        public Type NewPage { get; }

        public MenuSelectionChangedEventArgs(Type newPage)
        {
            NewPage = newPage;
        }
    }
}
