using System.Collections;
using System.Threading;

namespace LIFT.LiftSystem
{
    /**
     * This class works with all system as intermediary between GUI and system
     */
    public class LiftSystem
    {
        /**
         * Time that passenger approach to press button to call lift
         */
        public static readonly int PassengerPressBtnTime = 5000;

        /**
         * Statuses constants of the system
         */
        public static readonly int StatusStop = 0;
        public static readonly int StatusActive = 1;
        public static readonly int StatusPause = 2;

        /**
         * Building in system for working with lifts
         */
        protected Building.Building Building;

        /**
         * Status of the system
         */
        protected int Status;

        public LiftSystem(int floorsCount, int liftsCount)
        {
            Building = new Building.Building(floorsCount, liftsCount);
            Status = StatusStop;
        }

        /**
         * Creating new passenger in system. 
         */
        public void CreatePassenger(int weight, int necessaryFloor, int currentFloor)
        {
            if (Status != StatusActive)
            {
                return;
            }

            Passenger.Passenger passenger = new Passenger.Passenger(weight, necessaryFloor, currentFloor);
            Thread.Sleep(PassengerPressBtnTime);
            Building.PressButton(passenger);
        }
    }
}
