using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
    public interface IPersonListViewModel: INotifyPropertyChanged
    {
        ObservableCollection<IPersonViewModel> People { get; set; }
        IPersonViewModel SelectedPerson { get; set; }
        void AddPersonViewModel(IPersonViewModel personVM);
        void RemovePersonViewModel(IPersonViewModel personVM);
        void populatePeople(ObservableCollection<IPersonViewModel> peopleVMs);
    }
}
