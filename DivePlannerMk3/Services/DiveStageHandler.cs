using System;
using System.Collections.Generic;
using System.Linq;
using DivePlannerMk3.Contracts;
using DivePlannerMk3.Controllers;
using DivePlannerMk3.Controllers.DiveStages;
using DivePlannerMk3.Models;

namespace DivePlannerMk3.Services
{
    public class DiveStageHandler
    {
        private DiveResultsModel _outputResults;
        private IDiveStage[] _preDiveStages;
        private IDiveStage[] _diveStages;

        //updated using UpdateDiveStageHandler()
        private IDiveModel _diveModel;
        private IDiveProfile _diveProfile;
        private IDiveStepModel _diveStep;
        private IGasMixtureModel _selectedGasMixture;

        public DiveResultsModel RunDiveStages()
        {
            _outputResults = new DiveResultsModel();
            _diveStages = CreateDiveStages();
            _preDiveStages = CreatePreDiveStages();

            RunStages();

            return _outputResults;
        }

        public DiveParametersResultModel UpdateUsedDiveParameters(IDiveStepModel diveStep, IGasMixtureModel selectedGasMixture, IGasManagementModel gasManagementModel)
        {
            var diveParameters = new DiveParametersResultModel();

            var stepInfo = new PostDiveStageStepInfo(diveParameters, _diveModel, diveStep, selectedGasMixture, gasManagementModel, GetToleratedAmbientPressures().ToList());

            stepInfo.RunStage();

            return diveParameters;
        }

        public void UpdateDiveStageHandler(IDiveModel diveModel, IDiveProfile diveProfile, IDiveStepModel diveStep, IGasMixtureModel selectedGasMixture)
        {
            _diveModel = diveModel;
            _diveProfile = diveProfile;
            _diveStep = diveStep;
            _selectedGasMixture = selectedGasMixture;
        }

        private void RunStages()
        {
            foreach (var preDiveStage in _preDiveStages)
            {
                preDiveStage.RunStage();
            }

            //For each compartment run all stages
            for (int i = 0; i < _diveModel.CompartmentCount; i++)
            {
                foreach (var diveStage in _diveStages)
                {
                    diveStage.RunStage();
                }
            }
        }

        private IDiveStage[] CreatePreDiveStages()
        {
            return new IDiveStage[]
            {
                new PreDiveStageAmbientPressure(_diveProfile, _selectedGasMixture.Oxygen, _selectedGasMixture.Helium, _diveStep.Depth),
            };
        }

        private IDiveStage[] CreateDiveStages()
        {
            return new IDiveStage[]
            {
                new DiveStageTissuePressure(_diveModel, _diveProfile, _diveStep.Time),
                new DiveStageABValues(_diveModel, _diveProfile),
                new DiveStageToleratedAmbientPressure(_diveModel.CompartmentCount,_diveProfile),
                new DiveStageMaximumSurfacePressure(_diveModel.CompartmentCount, _diveProfile),
                new DiveStageCompartmentLoad(_diveModel, _diveProfile),
                new DiveStageResults(_diveModel.CompartmentCount,_outputResults, _diveProfile)
            };
        }

        private IEnumerable<double> GetToleratedAmbientPressures()
        {
            return _outputResults.DiveProfileStepOutput.Select(diveProfile => diveProfile.ToleratedAmbientPressureResult);
        }
    }
}
