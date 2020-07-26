﻿using CS_Take_Home_Challenge.DialogService.Dialogs;
using System.Windows;

namespace CS_Take_Home_Challenge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DialogService.IDialogService dialogService = new DialogService.DialogService(MainWindow);

            dialogService.Register<EditPersonDialogueViewModel, EditPersonDialog>();
            dialogService.Register<AddPersonDialogueViewModel, AddPersonDialog>();

            IPersonListViewModel personListViewModel = new PersonListViewModel();
            var viewModel = new MainWindowViewModel(dialogService, personListViewModel);
            var view = new MainWindow { DataContext = viewModel };

            view.ShowDialog();
        }
    }
}
