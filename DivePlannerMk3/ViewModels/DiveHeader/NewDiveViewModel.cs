using System;
using System.Reactive;
using DivePlannerMk3.Controllers;
using ReactiveUI;

namespace DivePlannerMk3.ViewModels.DiveHeader
{
    public class NewDiveViewModel
    {
        private MainWindowViewModel _mainWindowViewModel;
        private NewApplicationStateController _newApplicationStateController;

        public NewDiveViewModel(MainWindowViewModel mainWindowViewModel, NewApplicationStateController newApplicationStateController)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _newApplicationStateController = newApplicationStateController;

            NewCommand = ReactiveCommand.Create(CreateNewDiveSession);
        }

        public ReactiveCommand<Unit, Unit> NewCommand
        {
            get;
        }

        private void CreateNewDiveSession()
        {
            _mainWindowViewModel = _newApplicationStateController.NewApplication(_mainWindowViewModel);
        }
    }
}