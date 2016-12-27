namespace LIFT.LiftSystem.Events
{
    public class Event
    {
        private static Event _instance;

        public delegate void EventLiftOnFloorStop(int liftId, int floor);
        public event EventLiftOnFloorStop LiftOnFloorStop;

        public delegate void EventLiftOnFloorStart(int liftId, int floor);
        public event EventLiftOnFloorStart LiftOnFloorStart;

        public delegate void EventPassengerDelivered(int passengerId);
        public event EventPassengerDelivered PassengerDelivered;

        private Event() { }

        public static Event GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Event();
            }

            return _instance;
        }

        public void FireLiftOnFloorEvent(int liftId, int floor)
        {
            LiftOnFloorStop?.Invoke(liftId, floor);
        }

        public void FireLiftOnFloorStartEvent(int liftId, int floor)
        {
            LiftOnFloorStart?.Invoke(liftId, floor);
        }

        public void FirePassengerDelivered(int passengerId)
        {
            PassengerDelivered?.Invoke(passengerId);
        }
    }
}
