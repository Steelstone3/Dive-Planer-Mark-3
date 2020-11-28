using DivePlannerMk3.Contracts;

namespace DivePlannerMk3.Models
{
    public class GasManagementInfoModel : IGasManagementInfoModel
    {
        public int GasUsedForStep
        {
            get; set;
        }
        public int GasRemaining
        {
            get; set;
        }
    }
}