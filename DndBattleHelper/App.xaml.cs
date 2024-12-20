﻿using DndBattleHelper.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;
using DndBattleHelper.Views;
using DndBattleHelper.Helpers.DialogService;
using static DndBattleHelper.ViewModels.AddNewEnemyViewModel;

namespace DndBattleHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var view = new MainWindow();

            IDialogService dialogService = new DialogService(MainWindow);
            dialogService.Register<AddNewEnemyViewModel, AddNewEnemyView>();
            dialogService.Register<AddNewEnemyPresetViewModel, AddNewEnemyPresetView>();
            dialogService.Register<AddNewPlayerViewModel, AddNewPlayerView>();

            var viewModel = new MainWindowViewModel(dialogService);
            view.DataContext = viewModel;

            view.ShowDialog();
        }
    }

}
