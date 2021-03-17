using System.Collections.Generic;
using DivePlannerMk3.Contracts.DataAccessContracts;
using DivePlannerMk3.DataAccessLayer.DataMappers;
using DivePlannerMk3.ViewModels;

namespace DivePlannerMk3.DataAccessLayer.DataMappers
{
    public class ApplicationEntityModelDataMapper
    {
        public IEnumerable<IEntityModel> GenerateEntityModels(MainWindowViewModel mainViewModel)
        {
          return new List<IEntityModel>()
          {
            new DivePlanEntityModelDataMapper().ModelToEntity(mainViewModel.DivePlan),
            new DiveInfoEntityModelDataMapper().ModelToEntity(mainViewModel.DiveInfo),
            new DiveResultsEntityModelDataMapper().ModelToEntity(mainViewModel.DiveResults),
            //new DiveHeaderEntityModelDataMapper().ModelToEntity(mainViewModel.DiveHeader),
          };
        }
    }

}