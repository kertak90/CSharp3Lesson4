using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSenderLib.MVVM
{
    public class LambdaCommand : ICommand
    {
        private readonly Action<object> _onExecute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public LambdaCommand(Action<object> OnExecute, Func<object, bool> CanExecute = null)
        {
            _onExecute = OnExecute ?? throw new ArgumentNullException(nameof(OnExecute));
            _canExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _onExecute(parameter);
        }
    }
}
