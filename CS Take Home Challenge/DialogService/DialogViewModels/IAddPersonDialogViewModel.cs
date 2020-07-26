using System.ComponentModel;


namespace CS_Take_Home_Challenge.DialogService.DialogViewModels
{
    interface IAddPersonDialogViewModel:
       INotifyPropertyChanged
        , IDialogRequestClose
    {
        string Name { get; set; }

        string Address { get; set; }

        string Phone { get; set; }

        bool IsActive { get; set; }

        IPersonViewModel AddedPersonViewModel { get; set; }

        void AddPerson(object o);

        void CancelAddPerson(object obj);
    }
}
