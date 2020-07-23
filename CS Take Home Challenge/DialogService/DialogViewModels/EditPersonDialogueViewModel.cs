using CS_Take_Home_Challenge.DialogService.DialogViewModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Take_Home_Challenge.DialogService.Dialogs
{
    public class EditPersonDialogueViewModel:
        SubmitPersonInfoDialogViewModel
    {
        #region Private Fields
        private IPersonViewModel m_personViewModel;
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

        #region Properties
        #endregion

        #region Commands
        public ICommand ConfirmEditPersonCommand { get; }
        public ICommand CancelEditPersonCommand { get; }
        #endregion

        #region Public Methods
        public void ConfirmEditPerson(object o)
        {
            m_personViewModel.Name = Name;
            m_personViewModel.Address = Address;
            m_personViewModel.Phone = Phone;
            m_personViewModel.IsActive = IsActive;
            base.RaiseCloseRequestedEvent(this, new DialogCloseRequestedEventArgs(true));
        }

        public void CancelEditPerson(object obj)
        {
            base.RaiseCloseRequestedEvent(this, new DialogCloseRequestedEventArgs(false));
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
