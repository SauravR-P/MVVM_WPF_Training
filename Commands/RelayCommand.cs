using System.Windows.Input;

namespace Commands
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExceute;

        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }

        public RelayCommand(Action<object> execute, Predicate<object> canExceute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExceute = canExceute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object parameters)
        {
            return _canExceute == null ? true : _canExceute(parameters);
        }

        public void Execute(object parameters)
        {
            _execute(parameters);
        }
    }
}