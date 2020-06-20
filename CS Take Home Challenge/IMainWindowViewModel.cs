using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge
{
    interface IMainWindowViewModel
    {
        ObservableCollection<Person> People { get; set; }
    }
}
