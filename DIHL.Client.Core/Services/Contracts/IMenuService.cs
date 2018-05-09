using System;

namespace DIHL.Client.Core.Services.Contracts
{
    public interface IMenuService
    {
        event EventHandler<MenuSelectionChangedEventArgs> SelectionChanged;

        void RaiseSelectionChanged(Type newPage);
    }
}
