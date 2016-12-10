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

        public static readonly int TimeMovingBetweenFloors = 2000;

        public static readonly int FloorNotCalled = -1;
        public static readonly int StartFloorNumber = 1;

        /**
         * Statuses of lifts
         */
        public static readonly int StatusStandingOpenDoors = 1;
        public static readonly int StatusStandingCloseDoors = 2;
        public static readonly int StatusMoveDown = 3;
        public static readonly int StatusMoveUp = 4;

        /**
         * Id of the lift. Init of create object. NOT CHANGE IT THROUGH ALL WORK
         */
        protected int Id;

        /**
         * The current status of the lift
         */
        protected int _Status;

        public int Status
        {
            get { return _Status; }
        }


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
            AllPassengersInLift = new List<Passenger.Passenger>();

            Id = id;
            _Status = StatusStandingCloseDoors;
            _CurrentFloor = StartFloorNumber;

            OnFloorStop += eventCallbackOnFloorStop;
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
            Buttons[floor - 1] = true;
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

            return totalWeight < MaxWeight;
        }

        public bool AddPassenger(Passenger.Passenger passenger)
        {
            if (!AllowWeight(passenger.Weight))
            {
                Console.WriteLine("Lift" + Id + ": Passenger need to lose weight. Rejected weight " + passenger.Weight);
                return false;
            }

            Console.WriteLine("Lift" + Id + ": Adding passenger with weight " + passenger.Weight);
            AllPassengersInLift.Add(passenger);

            return true;
        }

        public List<Passenger.Passenger> ExitPassengers()
        {
            List<Passenger.Passenger> removePassengers = new List<Passenger.Passenger>();
            foreach (Passenger.Passenger passenger in AllPassengersInLift)
            {
                if (passenger.NecessaryFloor == CurrentFloor)
                {
                    removePassengers.Add(passenger);
                }
            }

            foreach (Passenger.Passenger passenger in removePassengers)
            {
                if (passenger.NecessaryFloor == CurrentFloor)
                {
                    Console.WriteLine("Passenger exit Lift" + Id + " on " + CurrentFloor + " floor");
                    passenger.ExitLift();
                    AllPassengersInLift.Remove(passenger);

                    ButtonsInside[passenger.NecessaryFloor - 1] = false;
                }
            }

            return removePassengers;
        }

        /**
         * Call lift on floor
         */

        public void Call(int floorNumber)
        {
            FloorsCalls[floorNumber - 1] = true;
        }

        /**
         * Lift run method
         */

        public void Run()
        {
            Console.WriteLine("Lift" + Id + ": Standing on " + CurrentFloor + " floor");
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
            if (_Status == StatusStandingCloseDoors || _Status == StatusStandingOpenDoors)
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
            int floorCalled = GetNeccessaryFloor();
            
            if (floorCalled == CurrentFloor)
            {
                StopOnFloor();
            } else if (floorCalled != FloorNotCalled)
            {
                NeccessaryFloor = floorCalled;
                bool moveUp = CheckMoveUp(NeccessaryFloor);
                int newStatus = moveUp ? StatusMoveUp : StatusMoveDown;

                ChangeStatus(newStatus);

                Console.WriteLine("Lift" + Id + ": Start movement to " + NeccessaryFloor + " floor");
            }
        }

        /**
         * Do actions when lift moving
         */

        protected void MovingActions() // TODO
        {
            Timer = Task.Factory.StartNew(TimerTask);

            int nextFloor = CalcNextFloor();
            Console.WriteLine("Lift" + Id + ": On " + CurrentFloor + " floor Passengers " + AllPassengersInLift.Count);
            Timer.Wait();
            _CurrentFloor = nextFloor;
            if (NeccessaryFloor == CurrentFloor)
            {
                StopOnFloor();
            }
        }

        protected void StopOnFloor()
        {
            Console.WriteLine("Lift" + Id + ": Stop on " + CurrentFloor + " floor");
            OnFloorStop?.Invoke(Id);
            ChangeStatus(StatusStandingOpenDoors);

            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException exception)
            {
                ChangeStatus(StatusStandingCloseDoors);
                NeccessaryFloor = FloorNotCalled;
            }
        }

        public int CalcSelectedFloorInside()
        {
            for (var i = 0; i < ButtonsInside.Length; i++)
            {
                if (ButtonsInside[i])
                {
                    return i;
                }
            }

            return FloorNotCalled;
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

            if (FloorsCalls[nextFloor - 1])
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
            return _Status == StatusMoveUp ? _CurrentFloor + 1 : (_Status == StatusMoveDown ? _CurrentFloor - 1 : -1);
        }

        /**
         * Checking if the passengers calls lift on floors
         */

        protected int GetNeccessaryFloor()
        {
            for (var floorNumber = 0; floorNumber < ButtonsInside.Length; floorNumber++)
            {
                if (ButtonsInside[floorNumber])
                {
                    return floorNumber + 1;
                }
            }

            for (var floorNumber = 0; floorNumber < FloorsCalls.Length; floorNumber++)
            {
                if (FloorsCalls[floorNumber])
                {
                    return floorNumber + 1;
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
            _Status = newStatus;
        }

        public void PressButtonInside(int floorSelected)
        {
            ButtonsInside[floorSelected - 1] = true;
        }
    }
}