using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Take_Home_Challenge.DialogService.Dialogs
{
    class EditPersonDialogueViewModel: IDialogRequestClose
    {
        #region Private Fields
        private IPersonViewModel m_personViewModel;
        #endregion

        #region Constructors
        public EditPersonDialogueViewModel(IPersonViewModel personViewModel)
        {
            m_personViewModel = personViewModel;
            //OkCommand = new CustomCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            //CancelCommand = new CustomCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }
        #endregion

        #region Properties
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion

        #region Specific Interface Implementation

        #region Implementation of <IDialogRequestClose>
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
        #endregion

        #endregion
        }
}
