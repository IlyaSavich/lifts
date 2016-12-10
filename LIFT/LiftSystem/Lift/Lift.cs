using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIFT.LiftSystem.Lift.Contracts;
using Timer = System.Timers.Timer;

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
         * Id of the lift. Init of create object. NOT CHANGE IT THROUGH ALL WORK
         */
        protected int Id;

        /**
         * The current status of the lift
         */
        protected int Status;

        /**
         * The lift on this floor at the moment
         */
        protected int _CurrentFloor;

        public int CurrentFloor
        {
            get { return _CurrentFloor; }
        }

        /**
         * The lift moving to this floor
         */
        protected int NeccessaryFloor;

        /**
         * Flag to top on the next floor
         */
        protected bool StopOnNextFloor;

        protected bool[] ButtonsInside;

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
         * Timer calc time when lift moving to the next floor
         */
        public static Task Timer;

        public delegate void EventOnFloorStop(int liftId);

        public event EventOnFloorStop OnFloorStop;

        public Lift(int id, int floorsCount, EventOnFloorStop eventCallbackOnFloorStop)
        {
            FloorsCalls = new bool[floorsCount];
            ButtonsInside = new bool[floorsCount];

            Id = id;
            Status = StatusStandingCloseDoors;
            _CurrentFloor = StartFloorNumber;

            OnFloorStop += eventCallbackOnFloorStop;
            InitTimer();
        }

        /**
         * Init task timer
         */

        protected void InitTimer()
        {
            Timer = new Task(TimerTask);
        }

        protected void TimerTask()
        {
            Thread.Sleep(TimeMovingBetweenFloors);
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
        public bool AllowWeight(int weight)
        {
            int totalWeight = weight;
            foreach (Passenger.Passenger passengerInLift in AllPassengersInLift)
            {
                totalWeight += passengerInLift.Weight;
            }

            return totalWeight > MaxWeight;
        }

        public bool AddPassenger(Passenger.Passenger passenger)
        { 
            if (!AllowWeight(passenger.Weight))
            {
                return false;
            }

            AllPassengersInLift.Add(passenger);

            return true;
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
                NeccessaryFloor = floorCalled;

                ChangeStatus(newStatus);
            }
        }

        /**
         * Do actions when lift moving
         */

        protected void MovingActions() // TODO
        {
            Timer.Start();

            int nextFloor = CalcNextFloor();
            Timer.Wait();
            if (NeccessaryFloor == nextFloor)
            {
                StopOnFloor();
            }
        }

        protected void StopOnFloor()
        {
            OnFloorStop?.Invoke(Id);

            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException exception)
            {
                
            }
        }

        /**
         * Calc if lift must stop on the next floor
         */

        protected void CalcMovingParameters() // TODO remove this
        {
            CheckNextFloorCalled();
        }

        /**
         * Checking if on the next floor passenger did call lift
         */

        protected bool CheckNextFloorCalled()
        {
            int nextFloor = CalcNextFloor();

            if (FloorsCalls[nextFloor])
            {
                StopOnNextFloor = true;
            }

            return StopOnNextFloor;
        }

        /**
         * Calculating number of next floor on lift movement
         */

        protected int CalcNextFloor()
        {
            return Status == StatusMoveUp ? _CurrentFloor + 1 : (Status == StatusMoveDown ? _CurrentFloor - 1 : -1);
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
            return (floorCalled - _CurrentFloor) > 0;
        }

        protected void ChangeStatus(int newStatus)
        {
            Status = newStatus;
        }

        public void PressButtonInside(int floorSelected)
        {
            ButtonsInside[floorSelected] = true;
        }
    }
}