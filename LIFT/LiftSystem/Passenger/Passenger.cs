using System.Security.Authentication;
using LIFT.LiftSystem.Passenger.Contracts;

namespace LIFT.LiftSystem.Passenger
{
    public class Passenger : IPassenger
    {
        public static readonly int StatusWaitOnFloor = 1;
        public static readonly int StatusOnNeccessaryFloor = 1;

       /**
        * Contents person characteristics
        */
        protected int _Weight;
        public int Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        protected int _NecessaryFloor;
        public int NecessaryFloor
        {
            get { return _NecessaryFloor; }
            set { _NecessaryFloor = value; }
        }

        protected int _CurrentFloor;
        public int CurrentFloor
        {
            get { return _CurrentFloor; }
            set { _CurrentFloor = value; }
        }

        protected int _LiftNumber;
        public int LiftNumber
        {
            get { return _LiftNumber; }
            set { _LiftNumber = value; }
        }

        /**
        * Contents person _Status
        */
        protected int _Status;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public Passenger(int weight, int necessaryFloor, int currentFloor, int liftNumber)
        {
            if (weight <= 0)
            {
                throw new InvalidCredentialException("Weight can't be zero or negative");
            }

            Weight = weight;
            NecessaryFloor = necessaryFloor;
            CurrentFloor = currentFloor;
            LiftNumber = liftNumber;
        }

        public void CallLift(Lift.Lift lift)
        {
            lift.Call(CurrentFloor);
            Status = StatusWaitOnFloor;
        }

        public bool EnterLift(Lift.Lift lift)
        {
            bool result = lift.AddPassenger(this);

            if (!result)
            {
                return false;
            }

            PressButtonInLift(lift);

            return true;
        }

        public void ExitLift()
        {
            Status = StatusOnNeccessaryFloor;
        }

        public void PressButtonInLift(Lift.Lift lift)
        {
            lift.PressButtonInside(NecessaryFloor);
        }
    }
}