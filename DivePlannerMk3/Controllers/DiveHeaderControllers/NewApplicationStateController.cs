using DivePlannerMk3.ViewModels;
using DivePlannerMk3.ViewModels.DiveApplication;
using DivePlannerMk3.ViewModels.DiveInformation;
using DivePlannerMk3.ViewModels.DivePlan;
using DivePlannerMk3.ViewModels.DiveResult;

namespace DivePlannerMk3.Controllers
{
    public class NewApplicationStateController
    {
        public MainWindowViewModel NewApplication(MainWindowViewModel mainWindowViewModel)
        {
            var diveProfileService = new DiveProfileService();
            mainWindowViewModel.DiveApplication = new DiveApplicationViewModel(diveProfileService);
            mainWindowViewModel.DiveApplication.DivePlanSetup = new DivePlanSetupViewModel(diveProfileService);
            mainWindowViewModel.DiveApplication.DiveInformation = new DiveInformationViewModel();
            mainWindowViewModel.DiveApplication.DiveResults = new DiveResultsViewModel();

            return mainWindowViewModel;
        }
    }
}