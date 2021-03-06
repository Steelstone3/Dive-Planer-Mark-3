using DivePlannerMk3.Contracts;

namespace DivePlannerMk3.Controllers
{
    public abstract class DiveStage : IDiveStage
    {
        public int Compartment
        {
            get; set;
        } = 0;

        public DiveStage()
        {
            Compartment = 0;
        }

        public void CompartmentCountCheck(int compartmentCount)
        {
            if(Compartment >= compartmentCount)
            {
                Compartment = 0;
            }
            else
            {
                Compartment += 1;
            }
        }

        public abstract void RunStage();
    }
}