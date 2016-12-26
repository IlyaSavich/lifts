using System.Windows.Forms;

namespace LIFT.LiftSystem.Events
{
    public class Event
    {
        private static Event Instance = null;

        public delegate void EventLiftOnFloorStop(int liftId, int floor);
        public event EventLiftOnFloorStop LiftOnFloorStop;

        public delegate void EventLiftOnFloorStart(int liftId, int floor);
        public event EventLiftOnFloorStart LiftOnFloorStart;


        private Event() { }

        public static Event GetInstance()
        {
            if (Event.Instance == null)
            {
                Event.Instance = new Event();
            }

            return Event.Instance;
        }

        public void FireLiftOnFloorEvent(int liftId, int floor)
        {
            EventLiftOnFloorStop handle = LiftOnFloorStop;

            if (handle != null)
            {
                handle(liftId,floor);
            }
        }

        public void FireLiftOnFloorStartEvent(int liftId, int floor)
        {
            EventLiftOnFloorStart handle = LiftOnFloorStart;

            if (handle != null)
            {
                handle(liftId, floor);
            }
        }






    }
}
