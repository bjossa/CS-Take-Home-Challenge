using System;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
    class CustomCommand :
        ICommand
    {
        #region private members

        private Action<object> m_execute;
        private Predicate<object> m_canExecute;

        #endregion

        #region constructors

        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {
            m_execute = execute;
            m_canExecute = canExecute;
        }

        #endregion

        #region Properties

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object parameter)
        {
            return m_canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            m_execute(parameter);
        }

        #endregion
    }
}
