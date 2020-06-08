using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CS_Take_Home_Challenge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // project step goals:
        // - when the app starts, create a button for displaying the people on a listView when the button is clicked (button at the top)
        // - also, when the program starts, the data from the file needs to be loaded and stored somewhere that is accessible to the UI

        //private void Application_Startup(object sender, StartupEventArgs e)
        //{
        //    // Create the startup window
        //    MainWindow wnd = new MainWindow();
        //    // Do stuff here, e.g. to the window
        //    wnd.Title = "People Displayer";
        //    // Show the window
        //    wnd.Show();

        //    // now, start the model running
        //    // parse the text file of people data, and print out the resulting list of people.
        //    PersonFileParser fileParser = new PersonFileParser();
        //    string filePath = "C:\\Users\\eric.raywood\\Desktop\\C# intro project\\Data.txt";
        //    fileParser.ParseFileToPeople(filePath);
        //    fileParser.people.ForEach(Console.WriteLine);
        //}
    }
}
