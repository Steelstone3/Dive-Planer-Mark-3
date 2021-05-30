using System.Reactive;
using DivePlannerMk3.Controllers;
using ReactiveUI;

namespace DivePlannerMk3.ViewModels.DiveHeader
{
    public class FileViewModel : ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        public FileViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _newDive = new NewDiveViewModel(_mainWindowViewModel, new NewApplicationStateController());

            SaveCommand = ReactiveCommand.Create(SaveDivePlannerState);
            OpenCommand = ReactiveCommand.Create(LoadDivePlannerState);
        }

        private NewDiveViewModel _newDive;
        public NewDiveViewModel NewDive
        {
            get => _newDive;
            set => this.RaiseAndSetIfChanged(ref _newDive, value);
        }

        public ReactiveCommand<Unit, Unit> SaveCommand
        {
            get;
        }

        public ReactiveCommand<Unit, Unit> OpenCommand
        {
            get;
        }

        //TODO AH this area needs a changable save name investigate Directory property of the SaveDialog
        private void SaveDivePlannerState()
        {
            var saveApplicationState = new SaveApplicationStateController();
            saveApplicationState.SaveApplication(_mainWindowViewModel);
        }

        //TODO AH this area needs work
        private void LoadDivePlannerState()
        {
            var loadApplicationState = new LoadApplicationStateController();
            loadApplicationState.LoadApplication(_mainWindowViewModel);
        }

    }
}