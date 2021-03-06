using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using DivePlannerMk3.DataAccessLayer.DataMappers;
using DivePlannerMk3.DataAccessLayer.Serialisers;
using DivePlannerMk3.ViewModels;

namespace DivePlannerMk3.Controllers
{
    public class SaveApplicationStateController
    {
        public async void SaveApplication(MainWindowViewModel mainWindowViewModel)
        {
             var saveFileDialog = new SaveFileDialog()
            {
                Directory = string.Empty,
                Title = $"Save Dive Profile",
                
                InitialFileName = $"DivePlan.json",
                
                Filters = new List<FileDialogFilter>()
                {
                    new FileDialogFilter() { Name = "Json", Extensions = { "json" } },
                },
            };

            var result = await saveFileDialog.ShowAsync(new Window());
            if (result != null)
            {
                var applicationConverter = new ApplicationEntityModelDataMapper();
                var applicationSerialiser = new ApplicationSerialiser();

                var entityModels = applicationConverter.ConvertModelsToEntities(mainWindowViewModel);
                //TODO AH Grab the save name from the UI somehow
                applicationSerialiser.SerialiseApplication(entityModels.ToList(), saveFileDialog.InitialFileName);
            }
        }
    }
}