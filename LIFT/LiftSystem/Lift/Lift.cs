using System;
using System.Collections.Generic;
using System.Threading;
using LIFT.LiftSystem.Lift.Contracts;

namespace LIFT.LiftSystem.Lift
{
    /**
     * This class working with lift substance. Lift delivering persons to his neccessary floors
     */

    public class Lift : ILift
    {
        /**
         *   Contents MaxWeight of passengers in Lift
         */
        public static readonly int MaxWeight = 400;

        public static readonly int TimeMovingBetweenFloors = 5000;

        public static readonly int FloorNotCalled = -1;
        public static readonly int StartFloorNumber = 0;

        /**
         * Statuses of lifts
         */
        public static readonly int StatusStandingOpenDoors = 1;
        public static readonly int StatusStandingCloseDoors = 2;
        public static readonly int StatusMoveDown = 3;
        public static readonly int StatusMoveUp = 3;

        /**
         * The current status of the lift
         */
        protected int Status;

        /**
         * The lift on this floor at the moment
         */
        protected int CurrentFloor;

        /**
         * The lift moving to this floor
         */
        protected int NeccessaryFloor;

        /**
         * The buttons inside the lift. It count depends on the number of floors in the building
         */
        protected List<bool> Buttons;

        /**
         * список Пассажиров в лифте добавить
         */
        protected List<Passenger.Passenger> AllPassengersInLift;

        /**
         * Floors where press call lift button
         */
        protected bool[] FloorsCalls;

        /**
         * Calculate environment variables while lift moving
         */
        protected Thread EnvThread;

        public Lift(int floorsCount)
        {
            FloorsCalls = new bool[floorsCount];
            Status = Lift.StatusStandingCloseDoors;
            CurrentFloor = Lift.StartFloorNumber;

            EnvThread = new Thread(CalcMovingParameters);
        }

        /**
         * Set button inside lift.
         * Lift will stop on this floor if it's on locate on his way or if the lift has no another route
         */

        public void SetButton(int floor)
        {
            this.Buttons[floor] = true;
        }

        /**
         * Checking weight of all Passengers in Lift
         */
        /*public bool CheckWeight(int weight)
        {
            bool allow = false;
            int sumWeight = 0;
            for (int i ==, , )
            {
                 
            }
            return allow;
        }*/

        public void AddPassenger()
        {
            // AllPassengersInLift.Add();
        }

        public void DeletePassenger()
        {
        }

        /**
         * Call lift on floor
         */

        public void Call(int floorNumber)
        {
            FloorsCalls[floorNumber] = true;
        }

        public void Run()
        {
            while (true)
            {
                ActionByStatus();
            }
        }

        protected void ActionByStatus()
        {
            if (Status == Lift.StatusStandingCloseDoors || Status == Lift.StatusStandingOpenDoors)
            {
                StandingActions();
            }
            else
            {
                MovingActions();
            }
        }

        protected void StandingActions()
        {
            int floorCalled = CheckFloorsCalls();

            if (floorCalled != Lift.FloorNotCalled)
            {
                bool moveUp = CheckMoveUp(floorCalled);
                int newStatus = moveUp ? Lift.StatusMoveUp : Lift.StatusMoveDown;

                ChangeStatus(newStatus);
            }
        }

        protected void MovingActions()
        {
            EnvThread.Start();
            Thread.Sleep(Lift.TimeMovingBetweenFloors);
        }

        protected void CalcMovingParameters()
        {
            
        }

        /*protected bool CheckNextFloorCalled()
        {
        }*/

        /**
         * Checking if the passengers calls lift on floors
         */

        protected int CheckFloorsCalls()
        {
            for (int floorNumber = 0; floorNumber < FloorsCalls.Length; floorNumber++)
            {
                bool called = FloorsCalls[floorNumber];

                if (called)
                {
                    return floorNumber;
                }
            }

            return Lift.FloorNotCalled;
        }

        /**
         * Checking if lift need to move up after call
         */

        protected bool CheckMoveUp(int floorCalled)
        {
            return (floorCalled - CurrentFloor) > 0 ? true : false;
        }

        protected void ChangeStatus(int newStatus)
        {
            Status = newStatus;
        }
    }
}