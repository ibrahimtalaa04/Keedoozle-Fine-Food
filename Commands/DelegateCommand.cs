using System.Windows.Input;

namespace Keedoozle_Fine_Food.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;


        private readonly Func<object, bool>? _canExecute;
        private readonly Action<object> _execute;

        public DelegateCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute);
            _canExecute = canExecute;
            _execute = execute;
        }
        public bool CanExecute(object? parameter)
        {
            return _canExecute is null || _canExecute(parameter);

        }
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
