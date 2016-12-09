using LIFT.LiftSystem.Passenger.Contracts;

namespace LIFT.LiftSystem.Passenger
{
    public class Passenger : IPassenger
    {
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
        * Contents person Status
        */
        protected int _Status;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public Passenger(int weight, int necessaryFloor, int currentFloor)
        {
            _Weight = weight;
            _NecessaryFloor = necessaryFloor;
            _CurrentFloor = currentFloor;
        }
    }
}