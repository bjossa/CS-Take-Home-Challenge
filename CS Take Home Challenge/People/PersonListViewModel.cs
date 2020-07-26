using System.Collections.ObjectModel;

namespace CS_Take_Home_Challenge
{
    public class PersonListViewModel :
        IPersonListViewModel
    {

        #region Constructors

        public PersonListViewModel(ObservableCollection<IPersonViewModel> people = null)
        {
            People = people ?? new ObservableCollection<IPersonViewModel>();
        }

        #endregion

        #region Implementation of IPersonListViewModel

        public ObservableCollection<IPersonViewModel> People { get; set; }

        public void AddPersonViewModel(IPersonViewModel personVM)
        {
            People.Add(personVM);
        }

        public void RemovePersonViewModel(IPersonViewModel personVM)
        {
            if (People.Contains(personVM))
            {
                People.Remove(personVM);
            }
        }

        public void populatePeople(ObservableCollection<IPersonViewModel> peopleVMs)
        {
            People.Clear();
            foreach (var personViewModel in peopleVMs)
            {
                AddPersonViewModel(personViewModel);
            }
        }

        #endregion
    }
}
