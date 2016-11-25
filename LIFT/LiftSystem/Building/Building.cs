using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using LIFT.LiftSystem.Building.Contracts;

namespace LIFT.LiftSystem.Building
{
    /**
     * This class works with substance   s    to building: lifts, buttons on floors, persons on floors
     */

    public class Building : IBuilding
    {
        /**
         * The array of all buttons from all floors
         */
        protected List<List<bool>> Buttons;

        /**
         * The array of lifts setting in the building
         */
        protected List<Lift.Lift> Lifts;

        /**
         * Count of installed lifts
         */
        protected int FloorsCount;

        /**
         * Count of floors in building
         */
        protected int LiftsCount;

        public Building(int floorsCount, int liftsCount)
        {
            this.FloorsCount= floorsCount;
            this.LiftsCount = liftsCount;
        }

        /**
         * Set button enabled on selected floor and select to specific lift
         */
        public void PressButton(int floor, int liftNumber)
        {
            if (floor > this.FloorsCount)
            {
                throw new InvalidExpressionException("The selected floor is invalid: " + floor);
            }

            if (liftNumber < 0 || liftNumber > this.LiftsCount)
            {
                throw new InvalidExpressionException("The selected lift is invalid: " + liftNumber);
            }
            this.Buttons[floor][liftNumber] = true;
        }
    }
}