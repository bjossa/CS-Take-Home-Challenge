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
using CS_Take_Home_Challenge.DialogService;
using CS_Take_Home_Challenge.DialogService.Dialogs;
using CS_Take_Home_Challenge.fileCommunication;
using System.IO;

namespace CS_Take_Home_Challenge
{
	public class MainWindowViewModel :
		INotifyPropertyChanged, 
		IMainWindowViewModel
	{

        #region Private Fields
        private IPersonParser m_parser;
		private IPersonFactory m_factory;
		private IDialogService m_dialogService;
		private IFileProxy m_fileProxy;
		private bool m_haveLoadedPeople;
		private IPersonViewModel m_selectedPerson;
		#endregion

		#region Constructors
		public MainWindowViewModel(IDialogService dialogService = null, IPersonListViewModel personListVM = null, IPersonParser parser = null, IPersonFactory factory = null, IFileProxy fileProxy = null)
		{
			m_dialogService = dialogService ?? new DialogService.DialogService(null);
			PersonListVM = personListVM ?? new PersonListViewModel();
			m_factory = factory ?? new PersonFactory();
			m_fileProxy = fileProxy;
			m_parser = parser ?? new PersonParser(factory);
			LoadCommands();
			HaveLoadedPeople = false;
		}
        #endregion

        #region Properties
        public IPersonListViewModel PersonListVM { get; }
		public bool HaveLoadedPeople
        {
			get
            {
				return m_haveLoadedPeople;
			}
			set
            {
				m_haveLoadedPeople = value;
				RaisePropertyChanged_(nameof(HaveLoadedPeople));

			}
        }

		public IPersonViewModel SelectedPerson
		{
			get => m_selectedPerson;
			set
			{
				m_selectedPerson = value;
				RaisePropertyChanged_(nameof(SelectedPerson));
			}
		}
		#endregion

		#region Commands
		public ICommand InputFilePathCommand { get; set; }
		public ICommand DisplayAddPersonDialogueCommand { get; set; }
		public ICommand DisplayEditPersonDialogueCommand { get; set; }
		public ICommand RemovePersonCommand { get; set; }
		#endregion

		#region Public Methods
		public void InputFileAndLoadPeople(object filePathO)
		{
			string filePath = filePathO as string;
			bool fileIsValid = OpenFileCommunication(filePath);
			if (fileIsValid)
			{
				LoadPeopleAsync();
			}
		}

		public bool OpenFileCommunication(string filePath)
        {
			try
            {
				if (!File.Exists(filePath))
                {
					return false;
                }
				else
                {
					m_fileProxy = new FileProxy(filePath);
					return true;
				}
			}
			catch (FileNotFoundException)
            {
				return false;
            }
        }

		public void DisplayAddPersonDialogue(object o)
		{
			var viewModel = new AddPersonDialogueViewModel(m_factory);

			bool? result = m_dialogService.ShowDialog(viewModel);

			if (result.HasValue)
			{
				if (result.Value)
				{
					PersonListVM.AddPersonViewModel(viewModel.AddedPersonViewModel);
				}
				else
				{
					// Cancelled
				}
			}
		}

		public void DisplayEditPersonDialogue(object o)
		{
			var viewModel = new EditPersonDialogueViewModel(SelectedPerson);
			m_dialogService.ShowDialog(viewModel);
		}

		public bool CanRemovePerson(object o)
		{
			return SelectedPerson != null;
		}

		public bool CanDisplayEditPersonDialogue(object o)
		{
			return SelectedPerson != null && SelectedPerson.IsActive == true;
		}

		public void RemovePerson(object o)
		{
			PersonListVM.RemovePersonViewModel(SelectedPerson);
		}


		public async Task LoadPeopleAsync()
		{
			try
            {
				List<IPerson> people = await Task.Run(ParsePeopleFromFile_);
				ObservableCollection<IPersonViewModel> peopleVMs = m_factory.CreatePeopleViewModels(people);
				PersonListVM.populatePeople(peopleVMs);
				HaveLoadedPeople = true;
			}
			catch (PeopleParsingException)
            {
				// do nothing
            }
			
		}
		#endregion

		#region Private Methods
		private void LoadCommands()
		{
			InputFilePathCommand = new CustomCommand(InputFileAndLoadPeople, (o) => { return true; });
			DisplayAddPersonDialogueCommand = new CustomCommand(DisplayAddPersonDialogue, (o) => { return true; });
			DisplayEditPersonDialogueCommand = new CustomCommand(DisplayEditPersonDialogue, CanDisplayEditPersonDialogue);
			RemovePersonCommand = new CustomCommand(RemovePerson, CanRemovePerson);
		}

		private void RaisePropertyChanged_(string propertyName)
		{
			if (propertyName != null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// call this function asynchronously
		private List<IPerson> ParsePeopleFromFile_()
		{
			string[] unparsedPeople = m_fileProxy.ReadLinesFromFile();
			List<IPerson> people = m_parser.ParseStringsToPeople(unparsedPeople);
			return people;
		}

		#endregion

		#region Specific Interface Implementation

		#region Implementation of INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

        #endregion

    }
}
