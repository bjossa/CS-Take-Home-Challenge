using System.Collections.ObjectModel;

namespace CS_Take_Home_Challenge
{
    public interface IPersonListViewModel
    {
        ObservableCollection<IPersonViewModel> People { get; set; }

        void AddPersonViewModel(IPersonViewModel personVM);

        void RemovePersonViewModel(IPersonViewModel personVM);

        void populatePeople(ObservableCollection<IPersonViewModel> peopleVMs);
    }
}
