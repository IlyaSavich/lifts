using System;
using System.Collections;
using System.Security.Authentication;
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
         * _Status of the system
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
        public void CreatePassenger(int weight, int necessaryFloor, int currentFloor, int liftNumber = 0)
        {
            if (Status != StatusActive)
            {
                return;
            }

            Passenger.Passenger passenger = new Passenger.Passenger(weight, necessaryFloor, currentFloor, liftNumber);
            try
            {
                Building.ValidatePassenger(passenger);
            }
            catch (InvalidCredentialException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }
            Building.AddPassenger(passenger);
            Thread.Sleep(PassengerPressBtnTime);
            Building.PressButton(passenger);
        }

        /**
         * Init building and lifts.
         */
        public void Init(int floorsCount, int liftsCount)
        {
            if (Status != StatusStop && Status != StatusPause)
            {
                return;
            }

            Building.Init(floorsCount, liftsCount);
        }

        /**
         * Start working
         */
        public bool Start()
        {
            if (Status != StatusStop)
            {
                return false;
            }

            Status = StatusActive;
            Building.Start();

            return true;
        }
    }
}
