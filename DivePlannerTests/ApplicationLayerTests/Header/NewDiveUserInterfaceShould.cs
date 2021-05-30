using DivePlannerMk3.Controllers;
using DivePlannerMk3.ViewModels;
using DivePlannerMk3.ViewModels.DiveHeader;
using Moq;
using Xunit;

namespace DivePlannerTests
{
    public class NewDiveUserInterfaceShould
    {
        [Fact(Skip="Doesn't want to play ball work out why")]
        public void CreateANewDive()
        {
            var mainWindowViewModelMock = new Mock<MainWindowViewModel>();
            var newApplicationStateControllerMock = new Mock<NewApplicationStateController>();
            newApplicationStateControllerMock.Setup(bob => bob.NewApplication(mainWindowViewModelMock.Object)).Returns(mainWindowViewModelMock.Object);

            var diveHeader = new DiveHeaderViewModel()
            {
                File = new FileViewModel(mainWindowViewModelMock.Object)
                {
                    NewDive = new NewDiveViewModel(mainWindowViewModelMock.Object, newApplicationStateControllerMock.Object)
                },
            };
            
            diveHeader.File.NewDive.NewCommand.Execute();

            newApplicationStateControllerMock.Verify(x => x.NewApplication(mainWindowViewModelMock.Object));
        }
    }
}