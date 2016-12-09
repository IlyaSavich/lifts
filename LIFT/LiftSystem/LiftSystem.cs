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

        protected Building.Building Building;

        public LiftSystem(int floorsCount, int liftsCount)
        {
            Building = new Building.Building(floorsCount, liftsCount);
        }

        /**
         * Wrapper method for getting full info
         */
        public Hashtable GetFullInfo()
        {
            return InformationRepository.GetFullInfo();
        }

        /**
         * Creating new passenger in system. 
         */
        public void CreatePassenger(int weight, int necessaryFloor, int currentFloor)
        {
            Passenger.Passenger passenger = new Passenger.Passenger(weight, necessaryFloor, currentFloor);
            Thread.Sleep(PassengerPressBtnTime);
            Building.PressButton(passenger);
        }
    }
}
