namespace LIFT.LiftSystem.Building.Contracts
{
    /**
      * Set button enabled on selected floor and select to specific lift
      */

    public interface IBuilding
    {
        void PressButton(int floor, int liftNumber);
    }
}