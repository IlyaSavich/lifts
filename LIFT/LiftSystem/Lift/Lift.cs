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
         * The buttons inside the lift. It count depends on the number of floors in the building
         */
        protected List<bool> Buttons;

        /**
         * Set button inside lift.
         * Lift will stop on this floor if it's on locate on his way or if the lift has no another route
         */

        public void SetButton(int floor)
        {
            this.Buttons[floor] = true;
        }
    }
}