using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge
{
    interface IPersonListViewModel
    {
        ObservableCollection<IPersonViewModel> People { get; set; }
        void AddPersonViewModel(IPersonViewModel personVM);
        void RemovePersonViewModel(IPersonViewModel personVM);

        //void removeAllPeople(

        void populatePeople(List<IPersonViewModel> peopleVMs);
    }
}
