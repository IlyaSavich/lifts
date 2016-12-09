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
         * Flag to top on the next floor
         */
        protected bool StopOnNextFloor = false;

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
            Status = StatusStandingCloseDoors;
            CurrentFloor = StartFloorNumber;

            EnvThread = new Thread(CalcMovingParameters);
        }

        /**
         * Set button inside lift.
         * Lift will stop on this floor if it's on locate on his way or if the lift has no another route
         */

        public void SetButton(int floor)
        {
            Buttons[floor] = true;
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

        /**
         * Lift run method
         */
        public void Run()
        {
            while (true)
            {
                ActionByStatus();
            }
        }

        /**
         * Doing action depends on status of lift movement
         */
        protected void ActionByStatus()
        {
            if (Status == StatusStandingCloseDoors || Status == StatusStandingOpenDoors)
            {
                StandingActions();
            }
            else
            {
                MovingActions();
            }
        }

        /**
         * Do actions when lift standing
         */
        protected void StandingActions()
        {
            int floorCalled = CheckFloorsCalls();

            if (floorCalled != FloorNotCalled)
            {
                bool moveUp = CheckMoveUp(floorCalled);
                int newStatus = moveUp ? StatusMoveUp : StatusMoveDown;

                ChangeStatus(newStatus);
            }
        }

        /**
         * Do actions when lift moving
         */
        protected void MovingActions() // TODO
        {
            EnvThread.Start();
            Thread.Sleep(TimeMovingBetweenFloors);
        }

        /**
         * Calc if lift must stop on the next floor
         */
        protected void CalcMovingParameters()
        {
            CheckNextFloorCalled();
        }

        /**
         * Checking if on the next floor passenger did call lift
         */
        protected bool CheckNextFloorCalled()
        {
            int nextFloor = Status == StatusMoveUp ? CurrentFloor + 1 : (Status == StatusMoveDown ? CurrentFloor - 1 : -1);

            if (FloorsCalls[nextFloor])
            {
                StopOnNextFloor = true;
            }

            return StopOnNextFloor;
        }

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

            return FloorNotCalled;
        }

        /**
         * Checking if lift need to move up after call
         */

        protected bool CheckMoveUp(int floorCalled)
        {
            return (floorCalled - CurrentFloor) > 0;
        }

        protected void ChangeStatus(int newStatus)
        {
            Status = newStatus;
        }
    }
}