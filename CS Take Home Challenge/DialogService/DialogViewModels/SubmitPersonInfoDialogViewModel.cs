using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge.DialogService.DialogViewModels
{
    // in terms of readability, a person looking at this class would
    // not understand what this class does, and this may be overEngineering
    // TODO: get rid of this class
    public abstract class SubmitPersonInfoDialogViewModel:
        INotifyPropertyChanged
        , IDialogRequestClose
    {
        #region private members
        private string m_Name;
        private string m_Address;
        private string m_Phone;
        private bool m_IsActive;
        #endregion

        #region properties
        public string Name
        {
            get { return m_Name; }
            set
            {
                m_Name = value;
                RaisePropertyChanged_("Name");
            }
        }
        public string Address
        {
            get { return m_Address; }
            set
            {
                m_Address = value;
                RaisePropertyChanged_("Address");
            }
        }
        public string Phone
        {
            get { return m_Phone; }
            set
            {
                m_Phone = value;
                RaisePropertyChanged_("Phone");
            }
        }
        public bool IsActive
        {
            get { return m_IsActive; }
            set
            {
                m_IsActive = value;
                RaisePropertyChanged_("IsActive");
            }
        }
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        #endregion

        #region protected methods
        protected void RaiseCloseRequestedEvent(object sender, DialogCloseRequestedEventArgs e)
        {
            CloseRequested?.Invoke(sender, e);
        }
        #endregion

        #region private methods
        private void RaisePropertyChanged_(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region implementation of <INotifyPropertyChanged>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
