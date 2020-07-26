using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CS_Take_Home_Challenge.Factory
{
    public interface IPersonFactory
    {
        ObservableCollection<IPersonViewModel> CreatePeopleViewModels(ICollection<IPerson> people);

        IPerson CreatePerson(string name, string address, string phone, bool isActive = true);

        IPersonViewModel CreatePersonViewModel(IPerson person);
    }
}
