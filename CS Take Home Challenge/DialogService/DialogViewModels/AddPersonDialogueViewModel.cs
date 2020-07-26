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
        IAddPersonDialogViewModel
    {
        #region Private Fields

        private IPersonFactory m_personFactory;
        private string m_Name;
        private string m_Address;
        private string m_Phone;
        private bool m_IsActive;

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

        #region Commands

        public ICommand AddPersonCommand { get; set; }
        public ICommand CancelAddPersonCommand { get; set; }

        #endregion

        #region private Methods

        private void RaisePropertyChanged_(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region implementation of IAddPersonDialogViewModel

        public string Name
        {
            get { return m_Name; }
            set
            {
                m_Name = value;
                RaisePropertyChanged_(nameof(Name));
            }
        }
        public string Address
        {
            get { return m_Address; }
            set
            {
                m_Address = value;
                RaisePropertyChanged_(nameof(Address));
            }
        }
        public string Phone
        {
            get { return m_Phone; }
            set
            {
                m_Phone = value;
                RaisePropertyChanged_(nameof(Phone));
            }
        }
        public bool IsActive
        {
            get { return m_IsActive; }
            set
            {
                m_IsActive = value;
                RaisePropertyChanged_(nameof(IsActive));
            }
        }

        public IPersonViewModel AddedPersonViewModel { get; set; }

        public void AddPerson(object o)
        {
            IPerson person = m_personFactory.CreatePerson(Name, Address, Phone, IsActive);
            AddedPersonViewModel = m_personFactory.CreatePersonViewModel(person);
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

        public void CancelAddPerson(object obj)
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false));
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


    }
}
