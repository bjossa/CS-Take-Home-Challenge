using CS_Take_Home_Challenge.DialogService.DialogViewModels;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CS_Take_Home_Challenge.DialogService.Dialogs
{
    public class EditPersonDialogueViewModel:
        IEditPersonDialogViewModel
    {
        #region Private Fields

        private IPersonViewModel m_personViewModel;
        private string m_Name;
        private string m_Address;
        private string m_Phone;
        private bool m_IsActive;
        #endregion

        #region Constructors

        public EditPersonDialogueViewModel(IPersonViewModel personViewModel)
        {
            m_personViewModel = personViewModel;
            ConfirmEditPersonCommand = new CustomCommand(ConfirmEditPerson, (o) => { return true; });
            CancelEditPersonCommand = new CustomCommand(CancelEditPerson, (o) => { return true; });
            Name = m_personViewModel.Name;
            Address = m_personViewModel.Address;
            Phone = m_personViewModel.Phone;
            IsActive = m_personViewModel.IsActive;
        }

        #endregion

        #region Commands

        public ICommand ConfirmEditPersonCommand { get; }
        public ICommand CancelEditPersonCommand { get; }

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

        #region implementation of IEditPersonDialogViewModel

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
        public void ConfirmEditPerson(object o)
        {
            m_personViewModel.Name = Name;
            m_personViewModel.Address = Address;
            m_personViewModel.Phone = Phone;
            m_personViewModel.IsActive = IsActive;
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

        public void CancelEditPerson(object obj)
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        #endregion
    }
}
