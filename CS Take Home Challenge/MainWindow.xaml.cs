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
        public IPersonListViewModel m_PersonListViewModel;
        public MainWindowViewModel m_mainWindowViewModel;

        public MainWindow()
        {
            m_PersonListViewModel = new PersonListViewModel();
            m_mainWindowViewModel = new MainWindowViewModel(m_PersonListViewModel);
            this.DataContext = m_mainWindowViewModel;
            PeopleListBox.DataContext = m_PersonListViewModel;

            InitializeComponent();
        }
    }
}
