using System;
using System.Windows.Input;

namespace Academy.Lib.UI
{
    public class RouteCommand : ICommand
    {
        #region Constructors

        public RouteCommand(Action execute)
            : this(execute, null) { }

        public RouteCommand(Action execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute();
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #endregion

        private readonly Action _execute = null;
        private readonly Predicate<object> _canExecute = null;
    }
}
