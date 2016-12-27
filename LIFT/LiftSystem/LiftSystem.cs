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

        public delegate void EventLiftOnFloorStop(int liftId, int floor);

        public delegate void EventLiftOnFloorStart(int liftId, int floor);

        public delegate void EventAddPassen(int liftId, int floor, int current);


        public LiftSystem(int floorsCount, int liftsCount)
        {
            Building = new Building.Building(floorsCount, liftsCount);
            Status = StatusStop;
        }

        /**
         * Creating new passenger in system. 
         */

        public Passenger.Passenger CreatePassenger(int weight, int necessaryFloor, int currentFloor, int liftNumber = 0)
        {
            if (Status != StatusActive)
            {
                return null;
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
            InformationRepository.Increment("created_passengers_count");

            return passenger;
        }

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

        public void Stop()
        {
            if (Status == StatusStop)
            {
                return;
            }

            Building.Stop();

            Status = StatusStop;
        }

        public void Pause()
        {
            if (Status == StatusPause)
            {
                return;
            }

            if (Status == StatusStop)
            {
                return;
            }
            Status = StatusPause;

            Building.Pause();
        }

        public void Resume()
        {
            if (Status == StatusStop)
            {
                return;
            }

            if (Status == StatusActive)
            {
                return;
            }
            Status = StatusActive;

            Building.Resume();
        }

        public int CountMovingLifts()
        {
            return Building.CountMovingLifts();
        }

        public int CountStandingLifts()
        {
            return Building.CountStandingLifts();
        }

        public int CountPassengers()
        {
            int count = 0;

            if (InformationRepository.Has("passengers_count"))
            {
                count += int.Parse(InformationRepository.Get("passengers_count"));
            }

            count += Building.CountPassengersInLifts();

            return count;
        }

        public string PassengerStatus(int id)
        {
            Passenger.Passenger passenger = Building.FindPassenger(id);

            if (passenger == null)
            {
                return "";
            }

            int floor;
            if (passenger.Status == Passenger.Passenger.StatusWaitOnFloor)
            {
                floor = passenger.CurrentFloor;
            }
            else if (passenger.Status == Passenger.Passenger.StatusMoveUp
                     || passenger.Status == Passenger.Passenger.StatusMoveDown)
            {
                floor = Building.GetLiftFloor(passenger.LiftNumber);
            }
            else
            {
                floor = passenger.NecessaryFloor;
            }


            return Passenger.Passenger.StatusText[passenger.Status] + " on " + floor;
        }
    }
}