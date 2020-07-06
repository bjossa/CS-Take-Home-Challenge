using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS_Take_Home_Challenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            IPersonListViewModel m_PersonListViewModel = new PersonListViewModel();
            MainWindowViewModel m_mainWindowViewModel = new MainWindowViewModel(m_PersonListViewModel);
            DataContext = m_mainWindowViewModel;
            PeopleListView.DataContext = m_PersonListViewModel;
            ShowPeopleButton.DataContext = m_PersonListViewModel; ;
            EditPeopleStackPanel.DataContext = m_PersonListViewModel;

        }
    }
}
