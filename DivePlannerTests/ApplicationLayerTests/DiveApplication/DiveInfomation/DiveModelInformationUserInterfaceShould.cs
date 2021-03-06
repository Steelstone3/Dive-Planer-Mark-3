using DivePlannerMk3.Controllers;
using DivePlannerMk3.Models;
using DivePlannerMk3.ViewModels.DivePlan;
using Moq;
using Xunit;

namespace DivePlannerTests
{
    public class DiveModelInformationUserInterfaceShould
    {
        [Fact]
        public void PopulateTheDiveInformationModel()
        {
            var diveProfileService = new Mock<DiveProfileService>();
            var diveModelSelectorViewModel = new DiveModelSelectorViewModel(diveProfileService.Object);

            diveModelSelectorViewModel.SelectedDiveModel = new Zhl16Buhlmann();

            Assert.NotNull(diveModelSelectorViewModel.SelectedDiveModel.DiveModelName);
            Assert.NotEmpty(diveModelSelectorViewModel.SelectedDiveModel.DiveModelName);
            
            Assert.Equal(16, diveModelSelectorViewModel.SelectedDiveModel.CompartmentCount);
            
            Assert.NotNull(diveModelSelectorViewModel.SelectedDiveModel.AValuesHelium);
            Assert.NotNull(diveModelSelectorViewModel.SelectedDiveModel.BValuesHelium);
            Assert.NotNull(diveModelSelectorViewModel.SelectedDiveModel.AValuesNitrogen);
            Assert.NotNull(diveModelSelectorViewModel.SelectedDiveModel.BValuesNitrogen);
            Assert.NotNull(diveModelSelectorViewModel.SelectedDiveModel.HeliumHalfTime);
            Assert.NotNull(diveModelSelectorViewModel.SelectedDiveModel.NitrogenHalfTime);
           
            Assert.NotEmpty(diveModelSelectorViewModel.SelectedDiveModel.AValuesHelium);
            Assert.NotEmpty(diveModelSelectorViewModel.SelectedDiveModel.BValuesHelium);
            Assert.NotEmpty(diveModelSelectorViewModel.SelectedDiveModel.AValuesNitrogen);
            Assert.NotEmpty(diveModelSelectorViewModel.SelectedDiveModel.BValuesNitrogen);
            Assert.NotEmpty(diveModelSelectorViewModel.SelectedDiveModel.HeliumHalfTime);
            Assert.NotEmpty(diveModelSelectorViewModel.SelectedDiveModel.NitrogenHalfTime);
        }
    }
}