using System;
using System.Windows.Input;

namespace WPFFuctionExample.Command
{
    public class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        Action<object> _action;

        public BaseCommand(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // _action?.Invoke();
            _action(parameter);
        }
    }
}
