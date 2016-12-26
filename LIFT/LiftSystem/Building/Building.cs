using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using LIFT.LiftSystem.Building.Contracts;

namespace LIFT.LiftSystem.Building
{
    /**
     * This class works with substance   s    to building: lifts, buttons on floors, persons on floors
     */

    public class Building
    {
        public static readonly int TimePassengerMovement = 2000;

        /**
         * The array of all buttons from all floors
         */
        protected bool[,] Buttons;

        /**
         * The array of passengers from all floors
         */
        protected List<Passenger.Passenger>[] Passengers;

        /**
         * The array of lifts setting in the building
         */
        protected Lift.Lift[] Lifts;

        /**
         * Threads of the lifts
         */
        protected Thread[] LiftsThreads;

        /**
         * Count of installed lifts
         */
        protected int FloorsCount;

        /**
         * Count of floors in building
         */
        protected int LiftsCount;

        /**
         * Timer calc time when passneger moving to lift or live in system after delivery
         */
        public static Task Timer;

        public Events.Event EventWrapper;

        public Building(int floorsCount, int liftsCount)
        {
            Init(floorsCount, liftsCount);
            InitLifts();
            SetEvents();
        }

        protected void TimerTask()
        {
            Thread.Sleep(TimePassengerMovement);
        }

        public void Init(int floorsCount, int liftsCount)
        {
            FloorsCount = floorsCount;
            LiftsCount = liftsCount;
            EventWrapper = Events.Event.GetInstance();

            Passengers = new List<Passenger.Passenger>[floorsCount];
            for (int i = 0; i < floorsCount; i++)
            {
                Passengers[i] = new List<Passenger.Passenger>();
            }
            Lifts = new Lift.Lift[liftsCount];
            LiftsThreads = new Thread[liftsCount];
            Buttons = new bool[floorsCount, liftsCount];
        }

        /**
         * Init rub thread method for each lift. Starting threads
         */

        public void InitLifts()
        {
            for (int i = 0; i < Lifts.Length; i++)
            {
                Lifts[i] = new Lift.Lift(i, FloorsCount);

                try
                {
                    LiftsThreads[i] = new Thread(Lifts[i].Run);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.StackTrace);
                    Environment.Exit(-1);
                }
            }
        }

        protected void SetEvents()
        {
            EventWrapper.LiftOnFloorStop += LiftEventOnFloorStop;
        }

        /**
         * Start working
         */

        public void Start()
        {
            foreach (Thread liftThread in LiftsThreads)
            {
                liftThread.Start();
            }
        }

        /**
         * Set button enabled on selected floor and select to specific lift
         */

        public void PressButton(Passenger.Passenger passenger)
        {
            try
            {
                Buttons[passenger.NecessaryFloor - 1, passenger.LiftNumber] = true;
                passenger.CallLift(Lifts[passenger.LiftNumber]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
                Environment.Exit(-1);
            }
        }

        /**
         * Adding passenger to floor
         */

        public void AddPassenger(Passenger.Passenger passenger)
        {
            Passengers[passenger.CurrentFloor - 1].Add(passenger);
        }

        public void LiftEventOnFloorStop(int liftId, int floor)
        {
            ExitLift(Lifts[liftId]);
            SetPassengersToLift(Lifts[liftId]);
            Buttons[Lifts[liftId].CurrentFloor - 1, liftId] = false;

            LiftsThreads[liftId].Interrupt();
        }

        protected void ExitLift(Lift.Lift lift)
        {
            Timer = Task.Factory.StartNew(TimerTask);

            int currentFloor = lift.CurrentFloor;
            List<Passenger.Passenger> removePassengers = lift.ExitPassengers();

            Timer.Wait();

            foreach (Passenger.Passenger passenger in removePassengers)
            {
                Passengers[currentFloor - 1].Remove(passenger);
            }
        }

        protected void SetPassengersToLift(Lift.Lift lift)
        {
            List<Passenger.Passenger> removePassengers = new List<Passenger.Passenger>();

            foreach (Passenger.Passenger passenger in Passengers[lift.CurrentFloor - 1])
            {
                if (!passenger.EnterLift(lift))
                {
                    break;
                }
                removePassengers.Add(passenger);
            }

            foreach (Passenger.Passenger passenger in removePassengers)
            {
                Passengers[lift.CurrentFloor - 1].Remove(passenger);
            }
        }

        public void ValidatePassenger(Passenger.Passenger passenger)
        {
            if (passenger.CurrentFloor > FloorsCount || passenger.CurrentFloor <= 0)
            {
                throw new InvalidCredentialException(
                    "Passenger current floor is invalid. Building has no such floors. " + passenger.CurrentFloor);
            }

            if (passenger.NecessaryFloor > FloorsCount || passenger.NecessaryFloor <= 0)
            {
                throw new InvalidCredentialException(
                    "Passenger neccesary floor is invalid. Building has no such floors. " + passenger.NecessaryFloor);
            }
        }
    }
}