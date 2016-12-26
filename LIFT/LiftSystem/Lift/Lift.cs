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

        protected Events.Event EventWrapper;

        public Lift(int id, int floorsCount)
        {
            FloorsCalls = new bool[floorsCount];
            ButtonsInside = new bool[floorsCount];
            AllPassengersInLift = new List<Passenger.Passenger>();

            Id = id;
            _Status = StatusStandingCloseDoors;
            _CurrentFloor = StartFloorNumber;

            EventWrapper = Events.Event.GetInstance();
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
            }
            else if (floorCalled != FloorNotCalled)
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
            bool isStopNextFloor = CalcNextFloorStop(nextFloor);

            Console.WriteLine("Lift" + Id + ": On " + CurrentFloor + " floor Passengers " + AllPassengersInLift.Count);
            Timer.Wait();

            _CurrentFloor = nextFloor;

            if (NeccessaryFloor == CurrentFloor)
            {
                StopOnFloor();
            }
            else if (isStopNextFloor)
            {
                StopOnFloor(false);
            }
        }

        protected void StopOnFloor(bool isNeccessaryFloor = true)
        {
            Console.WriteLine("Lift" + Id + ": Stop on " + CurrentFloor + " floor");
            EventWrapper.FireLiftOnFloorEvent(Id, CurrentFloor);
            int previousStatus = ChangeStatus(StatusStandingOpenDoors);

            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException exception)
            {
                FloorsCalls[CurrentFloor - 1] = false;

                if (isNeccessaryFloor)
                {
                    NeccessaryFloor = FloorNotCalled;
                    ChangeStatus(StatusStandingCloseDoors);
                }
                else
                {
                    ChangeStatus(previousStatus);
                }

                Console.WriteLine("Lift" + Id + ": Standing on " + CurrentFloor + " floor");
            }
        }

        /**
         * Checking if on the next floor passenger did call lift
         */

        protected bool CalcNextFloorStop(int nextFloor)
        {
            /*for (int i = 0; i < FloorsCalls.Length; i++)
            {
                Console.WriteLine("\tFloor" + (i + 1) + " -> " + FloorsCalls[i]);
                Console.WriteLine("\tInside" + (i + 1) + " -> " + ButtonsInside[i]);
            }*/
            return FloorsCalls[nextFloor - 1] || ButtonsInside[nextFloor - 1];
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
            int neccessaryFloor = CalcSelectedFloorInside();

            if (neccessaryFloor != FloorNotCalled)
            {
                return neccessaryFloor;
            }

            return CalcFloorCalled();
        }

        public int CalcSelectedFloorInside()
        {
            return CalcBtnListPress(ButtonsInside);
        }

        public int CalcFloorCalled()
        {
            return CalcBtnListPress(FloorsCalls);
        }

        protected int CalcBtnListPress(bool[] btns)
        {
            for (var i = CurrentFloor - 1; i >= 0; i--)
            {
                /*if (Id == 0)
                {
                    Console.WriteLine("Lift" + Id + ": btn " + floorNumber + " -> " + btns[floorNumber]);
                }*/
                if (btns[i])
                {
                    return i + 1;
                }
            }

            for (int i = CurrentFloor - 1; i < btns.Length; i++)
            {
                /*if (Id == 0)
                {
                    Console.WriteLine("Lift" + Id + ": btn " + i + " -> " + btns[i]);
                }*/
                if (btns[i])
                {
                    return i + 1;
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

        protected int ChangeStatus(int newStatus)
        {
            int previousStatus = Status;
            _Status = newStatus;

            return previousStatus;
        }

        public void PressButtonInside(int floorSelected)
        {
            ButtonsInside[floorSelected - 1] = true;
        }
    }
}