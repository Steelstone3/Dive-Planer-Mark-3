using DivePlannerMk3.Contracts;
using DivePlannerMK3.Contracts;

namespace DivePlannerMk3.Controllers.DiveStages
{
    public class DiveStageToleratedAmbientPressure : IDiveStage
    {
        private IDiveModel _diveModel;
        private IDiveProfile _diveProfile;

        public int Compartment
        {
            get; set;
        }

        public DiveStageToleratedAmbientPressure(IDiveModel diveModel, IDiveProfile diveProfile)
        {
            _diveModel = diveModel;
            _diveProfile = diveProfile;
        }

        public void RunStage()
        {
            CalculateToleratedAmbientPressure();
        }

        private void CalculateToleratedAmbientPressure()
        {
            //for (int i = 0; i < _diveProfile.TissuePressuresTotal.Count; i++)
            //{
            //TODO AH wont produce all the results
            _diveProfile.ToleratedAmbientPressures[Compartment] = (_diveProfile.TissuePressuresTotal[Compartment] - _diveModel.AValues[Compartment]) * _diveModel.BValues[Compartment];
            //}
        }
    }
}