namespace LIFT.LiftSystem.Lift.Contracts
{
    public interface ILift
    {
        /**
         * Set button inside lift.
         * Lift will stop on this floor if it's on locate on his way or if the lift has no another route
         */
        void SetButton(int floor);

       
    }
}