using System;
using System.Windows.Input;

namespace PODResourceTranslater.Commands
{
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Wird Ausgelößt wenn sich CanExecute ändert
        /// </summary>
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        protected void RaiseCanExecuteChanged(object? sender, EventArgs e)
        {
            this.CanExecuteChanged?.Invoke(sender, e);
        }
    }
}