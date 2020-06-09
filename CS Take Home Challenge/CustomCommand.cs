using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
	class CustomCommand : ICommand
	{
		private Action<object> execute;
		private Predicate<object> canExecute;
		public CustomCommand(Action<object> execute, Predicate<object> canExecute)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

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

		public bool CanExecute(object parameter)
		{
			return canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			execute(parameter);
		}
	}
}
