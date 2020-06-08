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

        PersonFileParser fileParser = new PersonFileParser();
        string filePath = "C:\\Users\\eric.raywood\\Desktop\\C# intro project\\Data.txt";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = fileParser;
        }

        // when the "Show People" button is clicked, do the parsing to populate the 'People' field in our PersonFileParser, so it is displayed
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fileParser.People.Count == 0)
            {
                fileParser.ParseFileToPeople(filePath);
            }
        }
    }
}
