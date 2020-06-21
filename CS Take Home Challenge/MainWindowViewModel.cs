using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
	class MainWindowViewModel : INotifyPropertyChanged //todo: should implement IMainWindowViewModel
	{

		#region Private Fields
		private Visibility m_arePeopleVisible = Visibility.Hidden;
		private PersonFileParser m_fileParser = new PersonFileParser(); // todo: fix this dependancy
		#endregion

		#region Constructors
		public MainWindowViewModel()
		{
			LoadData();
			LoadCommands();
		}
		#endregion

		#region Properties
		public Visibility ArePeopleVisible
		{
			get => m_arePeopleVisible;
			set
			{
				m_arePeopleVisible = value;
				RaisePropertyChanged("ArePeopleVisible");
			}
		}

		#endregion

		#region Dependency Properties
		#endregion

		#region Commands
		public ICommand ShowPeopleCommand { get; set; }
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        private void LoadCommands()
		{
			ShowPeopleCommand = new CustomCommand(showPeople, canShowPeople);
		}

		private bool canShowPeople(object obj)
		{
			return ArePeopleVisible != Visibility.Visible;
		}

		private void showPeople(object obj)
		{
			ArePeopleVisible = Visibility.Visible;
		}

		private void LoadData()
		{
			People = m_fileParser.GetAllPeople();
		}

		private void RaisePropertyChanged(string propertyName)
		{
			if (propertyName != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		#region Specific Interface Implementation

		#region Implementation of INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Implementation of IMainWindowViewModel
		public ObservableCollection<Person> People { get; set; } // todo: should be a list of PersonViewModel
        #endregion

        #endregion
    }
}
