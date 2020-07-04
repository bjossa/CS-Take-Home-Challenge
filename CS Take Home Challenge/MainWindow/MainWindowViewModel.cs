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
		public MainWindowViewModel(IPersonListViewModel personListVM = null, IPersonFileParser parser = null, IPersonFactory factory = null)
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
		public void InputFileFromPath(object filePathO)
		{
			string filePath = filePathO as string;
			LoadPeopleAsync(filePath);
		}


		public async void LoadPeopleAsync(string filePath)
		{
			// todo: validate the filePath before passing to external resource (maybe)
			try
            {
				List<Person> people = await Task.Run(() => { return m_parser.LoadPeopleFromFile(filePath); }); //todo: figure out how to handle exceptions with your async code
				ObservableCollection<IPersonViewModel> peopleVMs = m_factory.CreatePeopleViewModels(people);
				m_personListVM.populatePeople(peopleVMs);
			}
			catch (ErrorLoadingPeopleException)
            {
				//todo: display some error message to the UI
            }
			
		}
		#endregion

		#region Private Methods
		private void LoadCommands()
		{
			InputFilePathCommand = new CustomCommand(InputFileFromPath, (o) => { return true; });
		}

		#endregion

		#region Specific Interface Implementation

		#region Implementation of INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

        #endregion

    }
}
