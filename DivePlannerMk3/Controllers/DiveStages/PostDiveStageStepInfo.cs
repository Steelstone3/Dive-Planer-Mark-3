using DivePlannerMk3.Contracts;
using DivePlannerMk3.Models;
using System.Collections.Generic;

namespace DivePlannerMk3.Controllers.DiveStages
{
    public class PostDiveStageStepInfo : IDiveStage
    {
        private IDiveParametersResultModel _diveParametersModel;
        private IDiveModel _diveModel;
        private IDiveStepModel _diveStep;
        private IGasMixtureModel _gasMixture;
        private IGasManagementModel _gasManagement;
        private List<double> _toleratedAmbientPressures;

        public PostDiveStageStepInfo(IDiveParametersResultModel diveParametersModel, 
        IDiveModel diveModel, 
        IDiveStepModel diveStep, 
        IGasMixtureModel gasMixture, 
        IGasManagementModel gasManagement, 
        List<double> toleratedAmbientPressures)
        {            
            _diveParametersModel = diveParametersModel;
            _diveModel = diveModel;
            _diveStep = diveStep;
            _gasMixture = gasMixture;
            _gasManagement = gasManagement;
            _toleratedAmbientPressures = toleratedAmbientPressures;
        }

        public void RunStage()
        {
            PopulateHeader();
            PopulateDiveStepParameters();
        }

        private void PopulateHeader() => _diveParametersModel.DiveProfileStepHeader = _diveModel.DiveModelName + "\r\nDepth: " + _diveStep.Depth.ToString() + " Time: " + _diveStep.Time.ToString();

        private void PopulateDiveStepParameters()
        {
            var gasManagementController = new GasManagementController();

            _diveParametersModel.DiveModelUsed = _diveModel.DiveModelName;

            _diveParametersModel.Depth = _diveStep.Depth;
            _diveParametersModel.Time = _diveStep.Time;

            _diveParametersModel.GasName = _gasMixture.GasName;
            //TODO AH Oxygen, Helium and (Nitrogen (calculated)) aren't used here should they be added to the dive parameters used?
            _diveParametersModel.Oxygen = _gasMixture.Oxygen;
            _diveParametersModel.Helium = _gasMixture.Helium;

            _gasManagement.GasUsedForStep = gasManagementController.CalculateGasUsed(_diveStep.Depth, _diveStep.Time, _gasManagement.SacRate);
            _diveParametersModel.DiveCeiling = new DiveCeilingController().CalculateDiveCeiling(_toleratedAmbientPressures);
        }
    }
}
















