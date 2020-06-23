using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
	class MainWindowViewModel : INotifyPropertyChanged, IMainWindowViewModel
	{

		#region Private Fields
		private Visibility m_arePeopleVisible = Visibility.Hidden;
		private PersonFileParser m_fileParser = new PersonFileParser(); // todo: fix this dependancy
		private string m_filePath;
		#endregion

		#region Constructors
		public MainWindowViewModel()
		{
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
		public ICommand InputFilePathCommand { get; set; }
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		private void LoadCommands()
		{
			ShowPeopleCommand = new CustomCommand(showPeople, canShowPeople);
			InputFilePathCommand = new CustomCommand(inputFilePath, (o) => { return true; });
		}

        private void inputFilePath(object obj)
		{ 
			m_filePath = obj as string;
        }

        private bool canShowPeople(object obj)
		{
			bool arePeopleVisible = ArePeopleVisible != Visibility.Visible;
			bool haveFilePath = m_filePath != null;
			return arePeopleVisible && haveFilePath;
		}

		private void showPeople(object obj)
		{
			LoadPeopleAsync();
            ArePeopleVisible = Visibility.Visible;
        }

        private async void LoadPeopleAsync()
        {
			ObservableCollection<Person> people = await Task.Run(() => m_fileParser.GetAllPeople(m_filePath));
			foreach (var person in people)
            {
				People.Add(new PersonViewModel(person));
            }
			// todo: should also call some method outside this class to load the personViewModels as well.
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
		public ObservableCollection<IPersonViewModel> People { get; set; }
        #endregion

        #endregion
    }
}
