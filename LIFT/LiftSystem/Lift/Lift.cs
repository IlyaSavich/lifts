using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIFT.LiftSystem.Lift
{
    /**
     * This class working with lift substance. Lift delivering persons to his neccessary floors
     */

    public class Lift
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
         * Flag that using in run for checking when the lift need to stop
         */
        protected bool Stopped;

        /**
         * Flag that using in run for checking when the lift need to pause
         */
        protected bool Paused;

        /**
         * The current status of the lift
         */
        protected int _Status;

        public int Status
        {
            get { return _Status; }
        }

        protected int PreviousStatus;


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
            SetStartConfiguration();

            EventWrapper = Events.Event.GetInstance();
        }

        public void SetStartConfiguration()
        {
            _Status = StatusStandingCloseDoors;
            _CurrentFloor = StartFloorNumber;
        }

        protected void TimerTask()
        {
            Thread.Sleep(TimeMovingBetweenFloors);
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
                EventWrapper.FireAddPassenger(Id, CurrentFloor, NeccessaryFloor);
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
                    InformationRepository.Add("total_moved_weight", passenger.Weight);
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

        public void ExitAllPassengers()
        {
            foreach (Passenger.Passenger passenger in AllPassengersInLift)
            {
                passenger.ExitLift();
                InformationRepository.Add("total_moved_weight", passenger.Weight);
            }

            AllPassengersInLift.Clear();
        }

        /**
         * Call lift on floor
         */

        public void Call(int floorNumber)
        {
            FloorsCalls[floorNumber - 1] = true;
        }

        public void ClearFloorCalls()
        {
            for (int i = 0; i < FloorsCalls.Length; i++)
            {
                FloorsCalls[i] = false;
            }
        }

        public void UnactivateAllButtons()
        {
            for (int i = 0; i < ButtonsInside.Length; i++)
            {
                ButtonsInside[i] = false;
            }
        }

        /**
         * Lift run method
         */

        public void Run()
        {
            Console.WriteLine("Lift" + Id + ": Standing on " + CurrentFloor + " floor");
            while (true)
            {
                while (Paused)
                {
                }

                if (Stopped)
                {
                    _Status = StatusStandingOpenDoors;
                    ExitAllPassengers();
                    UnactivateAllButtons();
                    ClearFloorCalls();
                    _Status = StatusStandingCloseDoors;
                    NeccessaryFloor = FloorNotCalled;

                    Console.WriteLine("Lift" + Id + ": STOPPED on " + CurrentFloor + " floor");
                    Stopped = false;
                    break;
                }

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
                UpdateTripsCountInfo();
                NeccessaryFloor = floorCalled;
                int newStatus = GetNewStatus(NeccessaryFloor);

                ChangeStatus(newStatus);

                Console.WriteLine("Lift" + Id + ": Start movement to " + NeccessaryFloor + " floor");
            }
        }

        protected int GetNewStatus(int neccessaryFloor)
        {
            if (neccessaryFloor == FloorNotCalled)
            {
                return FloorNotCalled;
            }

            bool moveUp = CheckMoveUp(neccessaryFloor);

            return moveUp ? StatusMoveUp : StatusMoveDown;
        }

        /**
         * Do actions when lift moving
         */

        protected void MovingActions()
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
            PreviousStatus = ChangeStatus(StatusStandingOpenDoors);
            EventWrapper.FireLiftOnFloorEvent(Id, CurrentFloor);

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
                    ChangeStatus(PreviousStatus);
                }

                Console.WriteLine("Lift" + Id + ": Standing on " + CurrentFloor + " floor");
            }
        }

        protected void UpdateTripsCountInfo()
        {
            int newStatus = GetNewStatus(GetNeccessaryFloor());

            if ((newStatus == StatusMoveDown || newStatus == StatusMoveUp) && newStatus != PreviousStatus)
            {
                InformationRepository.Increment("trips_count");

                Console.WriteLine(AllPassengersInLift.Count);
                if (AllPassengersInLift.Count == 0)
                {
                    InformationRepository.Increment("idle_trips_count");
                }
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

        public void Stop()
        {
            Stopped = true;
            Paused = false;
        }

        public void Pause()
        {
            Paused = true;
            Console.WriteLine("Lift" + Id + ": PAUSED");
        }

        public void Resume()
        {
            Paused = false;
            Console.WriteLine("Lift" + Id + ": RESUMED");
        }
    }
}