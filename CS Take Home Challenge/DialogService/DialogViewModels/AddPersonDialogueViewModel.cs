using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Take_Home_Challenge.DialogService.Dialogs
{
    class AddPersonDialogueViewModel : IDialogRequestClose, INotifyPropertyChanged
    {
        #region Private Fields
        private string m_Name;
        private string m_Address;
        private string m_Phone;
        private bool m_IsActive;
        #endregion

        #region Constructors
        public AddPersonDialogueViewModel()
        {
            AddPersonCommand = new CustomCommand(AddPerson, (o) => { return true; });
            CancelAddPersonCommand = new CustomCommand(CancelAddPerson, (o) => { return true; });
            Name = "";
            Phone = "";
            Address = "";
            IsActive = true;

        }

        #endregion

        #region Properties
        public virtual string Name
        {
            get { return m_Name; }
            set
            {
                m_Name = value;
                RaisePropertyChanged_("Name");
            }
        }
        public virtual string Address
        {
            get { return m_Address; }
            set
            {
                m_Address = value;
                RaisePropertyChanged_("Address");
            }
        }
        public virtual string Phone
        {
            get { return m_Phone; }
            set
            {
                m_Phone = value;
                RaisePropertyChanged_("Phone");
            }
        }
        public virtual bool IsActive
        {
            get { return m_IsActive; }
            set
            {
                m_IsActive = value;
                RaisePropertyChanged_("IsActive");
            }
        }

        public IPersonViewModel AddedPersonViewModel { get; set; }
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        public ICommand AddPersonCommand { get; set;  }
        public ICommand CancelAddPersonCommand { get; set;  }
        #endregion

        #region Public Methods
        public void AddPerson(object o)
        {
            Person person = new Person(Name, Address, Phone, IsActive);
            AddedPersonViewModel = new PersonViewModel(person); //todo: do something with this viewModel, get it to the PersonListViewModelSomeHow
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

        public void CancelAddPerson(object obj)
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false));
        }
        #endregion

        #region Private Methods
        private void RaisePropertyChanged_(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Specific Interface Implementation

        #region Implementation of <IDialogRequestClose>
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
        #endregion

        #region Implementation of <INotifyPropertyChanged>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #endregion
    }
}
