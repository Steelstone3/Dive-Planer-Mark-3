using DivePlannerMk3.Contracts;
using DivePlannerMk3.Controllers;
using DivePlannerMk3.ViewModels;
using DivePlannerMk3.ViewModels.DiveApplication;
using DivePlannerMk3.ViewModels.DiveHeader;
using DivePlannerMk3.ViewModels.DiveInformation;
using DivePlannerMk3.ViewModels.DivePlan;
using DivePlannerMk3.ViewModels.DiveResult;
using Moq;
using Xunit;

namespace DivePlannerTests
{
    public class NewDiveBusinessLayerShould
    {
        [Fact]
        public void ResetAllDiveApplicationModels()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.DiveApplication = null;
            mainWindowViewModel.DiveHeader = null;

            Assert.Null(mainWindowViewModel.DiveApplication);
            Assert.Null(mainWindowViewModel.DiveHeader);

            var newApplicationState = new NewApplicationStateController();
            mainWindowViewModel = newApplicationState.NewApplication(mainWindowViewModel);

            Assert.NotNull(mainWindowViewModel.DiveApplication);
            Assert.NotNull(mainWindowViewModel.DiveApplication.DiveInformation);
            Assert.NotNull(mainWindowViewModel.DiveApplication.DivePlanSetup);
            Assert.NotNull(mainWindowViewModel.DiveApplication.DiveResults);
            Assert.Null(mainWindowViewModel.DiveHeader);
        }
    }
}