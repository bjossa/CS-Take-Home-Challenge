using System.ComponentModel;

namespace CS_Take_Home_Challenge.DialogService.DialogViewModels
{
    interface IEditPersonDialogViewModel:
        INotifyPropertyChanged
        , IDialogRequestClose
    {
        string Name { get; set; }

        string Address { get; set; }

        string Phone { get; set; }

        bool IsActive { get; set; }

        void ConfirmEditPerson(object o);

        void CancelEditPerson(object obj);
    }
}
