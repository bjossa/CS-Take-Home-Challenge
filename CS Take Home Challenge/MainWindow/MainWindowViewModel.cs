using CS_Take_Home_Challenge.fileParsing;
using CS_Take_Home_Challenge.Factory;
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
using System.IO.Packaging;

namespace CS_Take_Home_Challenge
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{

		#region Private Fields
		private IPersonListViewModel m_personListVM;
		private IPersonFileParser m_parser;
		private IPersonFactory m_factory;
		#endregion

		#region Constructors
		public MainWindowViewModel(IPersonListViewModel personListVM = null, PersonFileParser parser = null, PersonFactory factory = null)
		{
			m_personListVM = personListVM ?? new PersonListViewModel();
			m_parser = parser ?? new PersonFileParser();
			m_factory = factory ?? new PersonFactory();
			LoadCommands();
		}
		#endregion

		#region Properties

		#endregion

		#region Dependency Properties
		#endregion

		#region Commands
		public ICommand InputFilePathCommand { get; set; }
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		private void LoadCommands()
		{
			InputFilePathCommand = new CustomCommand(inputFileCommand, (o) => { return true; });
		}

        private void inputFileCommand(object filePathO)
		{
			string filePath = filePathO as string;
			LoadPeopleAsync(filePath);
        }

		// the input file command will trigger an async load of the people, which is a call to the personFileParser, and then it will take those people, and it will pass them to the personFactory, and then pass the results to the PersonListVM
        private async void LoadPeopleAsync(string filePath)
        {
			// todo: validate the filePath before passing to external resource.
			List<Person> people = await Task.Run(() => m_parser.LoadPeopleFromFile(filePath));
			ObservableCollection<IPersonViewModel> peopleVMs = m_factory.CreatePeopleViewModels(people);
			m_personListVM.populatePeople(peopleVMs);
		}

		#endregion

		#region Specific Interface Implementation

		#region Implementation of INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

        #endregion

    }
}
