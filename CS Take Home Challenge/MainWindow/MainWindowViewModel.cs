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

namespace CS_Take_Home_Challenge
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{

        #region Private Fields
        private IPersonFileParser m_parser;
		private IPersonFactory m_factory;
		private IDialogService m_dialogService;
		private bool m_haveFilePath;
		#endregion

		#region Constructors
		public MainWindowViewModel(IDialogService dialogService = null, IPersonListViewModel personListVM = null, IPersonFileParser parser = null, IPersonFactory factory = null)
		{
			m_dialogService = dialogService ?? new DialogService.DialogService(null); // could be improved and still work for testing?
			PersonListVM = personListVM ?? new PersonListViewModel();
			m_factory = factory ?? new PersonFactory();
			m_parser = parser ?? new PersonFileParser(factory);
			LoadCommands();
			HaveFilePath = false;
		}
        #endregion

        #region Properties
        public IPersonListViewModel PersonListVM { get; }
		public bool HaveFilePath
        {
			get
            {
				return m_haveFilePath;
			}
			set
            {
				m_haveFilePath = value;
				RaisePropertyChanged_(nameof(HaveFilePath));

			}
        }
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        public ICommand InputFilePathCommand { get; set; }
		public ICommand DisplayAddPersonDialogueCommand { get; set; }
		public ICommand DisplayEditPersonDialogueCommand { get; set; }
		public ICommand RemovePersonCommand { get; set; }
		#endregion

		#region Public Methods
		public void InputFileFromPath(object filePathO)
		{
			string filePath = filePathO as string;
			LoadPeopleAsync(filePath);
		}

		public void DisplayAddPersonDialogue(object o)
		{
			var viewModel = new AddPersonDialogueViewModel();

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
				// todo: destroy the viewModel here?
			}
		}

		public void DisplayEditPersonDialogue(object o)
		{
			//stub
		}

		// todo: should these 'can...' methods instead call a method in the PersonListVM?
		public bool CanRemovePerson(object o)
		{
			return PersonListVM.SelectedPerson != null;
		}

		public bool CanDisplayEditPersonDialogue(object o)
		{
			return PersonListVM.SelectedPerson != null && PersonListVM.SelectedPerson.IsActive == true;
		}

		public void RemovePerson(object o)
		{
			PersonListVM.RemovePersonViewModel(PersonListVM.SelectedPerson);
		}


		public async void LoadPeopleAsync(string filePath)
		{
			// todo: validate the filePath before passing to external resource (maybe)
			try
            {
				List<Person> people = await Task.Run(() => { return m_parser.LoadPeopleFromFile(filePath); }); //todo: figure out how to handle exceptions with your async code
				ObservableCollection<IPersonViewModel> peopleVMs = m_factory.CreatePeopleViewModels(people);
				PersonListVM.populatePeople(peopleVMs);
				HaveFilePath = true;
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

		#endregion

		#region Specific Interface Implementation

		#region Implementation of INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

        #endregion

    }
}
