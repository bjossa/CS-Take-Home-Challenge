using CS_Take_Home_Challenge.DialogService.DialogViewModels;
using CS_Take_Home_Challenge.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Take_Home_Challenge.DialogService.Dialogs
{
    public class AddPersonDialogueViewModel :
        SubmitPersonInfoDialogViewModel
    {
        #region Private Fields
        private IPersonFactory m_personFactory;
        #endregion

        #region Constructors
        public AddPersonDialogueViewModel(IPersonFactory personFactory = null)
        {
            AddPersonCommand = new CustomCommand(AddPerson, (o) => { return true; });
            CancelAddPersonCommand = new CustomCommand(CancelAddPerson, (o) => { return true; });
            m_personFactory = personFactory ?? new PersonFactory();
            Name = "";
            Phone = "";
            Address = "";
            IsActive = true;
        }

        #endregion

        #region Properties
        public IPersonViewModel AddedPersonViewModel { get; set; }
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        public ICommand AddPersonCommand { get; set; }
        public ICommand CancelAddPersonCommand { get; set; }
        #endregion

        #region Public Methods
        public void AddPerson(object o)
        {
            IPerson person = m_personFactory.CreatePerson(Name, Address, Phone, IsActive);
            AddedPersonViewModel = m_personFactory.CreatePersonViewModel(person);
            base.RaiseCloseRequestedEvent(this, new DialogCloseRequestedEventArgs(true));
        }

        public void CancelAddPerson(object obj)
        {
            base.RaiseCloseRequestedEvent(this, new DialogCloseRequestedEventArgs(false));
        }
        #endregion


    }
}
