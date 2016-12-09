namespace LIFT.LiftSystem.Building.Contracts
{
    /**
      * Set button enabled on selected floor and select to specific lift
      */

    public interface IBuilding
    {
        void PressButton(Passenger.Passenger passenger);
        void Init(int floorsCount, int liftsCount);
        void Start();
        void AddPassenger(Passenger.Passenger passenger);
    }
}