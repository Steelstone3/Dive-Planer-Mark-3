using System;
using System.Collections.Generic;
using DivePlannerMk3.Contracts.DataAccessContracts;
using DivePlannerMk3.DataAccessLayer.DataMappers;
using DivePlannerMk3.DataAccessLayer.EntityModels;
using DivePlannerMk3.ViewModels;
using Newtonsoft.Json.Linq;

namespace DivePlannerMk3.DataAccessLayer.DataMappers
{
    public class ApplicationEntityModelDataMapper
    {
        public IEnumerable<IEntityModel> ConvertModelsToEntities(MainWindowViewModel mainViewModel)
        {
            return new List<IEntityModel>()
          {
            new DivePlanEntityModelDataMapper().ModelToEntity(mainViewModel.DivePlan),
            new DiveInfoEntityModelDataMapper().ModelToEntity(mainViewModel.DiveInfo),
            new DiveResultsEntityModelDataMapper().ModelToEntity(mainViewModel.DiveResults),
            //new DiveHeaderEntityModelDataMapper().ModelToEntity(mainViewModel.DiveHeader),
          };
        }

        public void ConvertEntitiesToModels(List<IEntityModel> entityModels, MainWindowViewModel mainWindowViewModel)
        {
            //TODO AH each to take specific IEntityModel
            mainWindowViewModel.DivePlan = new DivePlanEntityModelDataMapper().EntityToModel((DivePlanEntityModel)entityModels[0]);
            //new DiveInfoEntityModelDataMapper().EntityToModel((DiveInfoEntityModel)entityModels[1]),
            //new DiveResultsEntityModelDataMapper().EntityToModel((DiveResultsEntityModel)entityModels[2]),
            //new DiveHeaderEntityModelDataMapper().EntityToModel(entityModels.DiveHeader),

        }
    }

}
