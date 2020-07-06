using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CS_Take_Home_Challenge
{
    //todo: should this class be an observable collection itself?
    public class PersonListViewModel : IPersonListViewModel
    {
        #region Private Fields
        private Visibility m_peopleVisibility = Visibility.Hidden;
        private IPersonViewModel m_selectedPerson;
        #endregion

        #region Constructors
        public PersonListViewModel(ObservableCollection<IPersonViewModel> people = null)
        {
            People = people ?? new ObservableCollection<IPersonViewModel>();
            LoadCommands_();
        }
        #endregion

        #region Properties
        public IPersonViewModel SelectedPerson
        {
            get => m_selectedPerson;
            set
            {
                m_selectedPerson = value;
                RaisePropertyChanged_("SelectedPerson");
            }
        }
        public Visibility PeopleVisibility
        {
            get => m_peopleVisibility;
            set
            {
                m_peopleVisibility = value;
                RaisePropertyChanged_("PeopleVisibility"); //todo: test that this was raised? (subscribe in test class?)
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        public ICommand ShowPeopleCommand { get; set; }
        public ICommand DisplayAddPersonDialogueCommand { get; set; }
        public ICommand DisplayEditPersonDialogueCommand { get; set; }
        public ICommand RemovePersonCommand { get; set; }
        #endregion

        public void DisplayAddPersonDialogue(object o)
        {
            //stub
        }

        public void DisplayEditPersonDialogue(object o)
        {
            //stub
        }

        public void RemovePerson(object o)
        {
            RemovePersonViewModel(SelectedPerson);
        }

        public bool CanDisplayEditPersonDialogue(object o)
        {
            return SelectedPerson != null && SelectedPerson.IsActive == true;
        }

        public bool CanRemovePerson(object o)
        {
            return SelectedPerson != null;
        }

        #region Public Methods
        public bool CanShowPeople(object obj)
        {
            return PeopleVisibility != Visibility.Visible;
        }

        public void ShowPeople(object obj)
        {
            PeopleVisibility = Visibility.Visible;
        }
        #endregion

        #region Private Methods

        private void LoadCommands_()
        {
            ShowPeopleCommand = new CustomCommand(ShowPeople, CanShowPeople);
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

        #region Implementation of <IPersonListViewModel>

        public ObservableCollection<IPersonViewModel> People { get; set; }

        public void AddPersonViewModel(IPersonViewModel personVM)
        {
            People.Add(personVM);
        }
        // todo: what happens when this person isn't present?
        public void RemovePersonViewModel(IPersonViewModel personVM)
        {
            if (People.Contains(personVM))
            {
                People.Remove(personVM);
            }
        }

        // todo: should this change the visibility of the people?
        public void populatePeople(ObservableCollection<IPersonViewModel> peopleVMs)
        {
            People.Clear(); //todo: does this work, and should we be calling RemovePersonViewModel?
            foreach (var personViewModel in peopleVMs)
            {
                AddPersonViewModel(personViewModel);
            }
        }

        #endregion

        #endregion
    }
}
