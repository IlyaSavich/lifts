using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFT.LiftSystem.Lift.Passenger
{
    public class Passenger
    {
        /**
       * Contents person charakteristiks
       */
        protected int Weight;

        protected int NecessaryFloor;

        protected int CurrentFloor;
        /**
         * Contents person Status
         */
        protected int Status;

        public Passenger(int weight, int necessaryFloor, int currentFloor)
        {
            this.Weight = weight;
            this.NecessaryFloor = necessaryFloor;
            this.CurrentFloor = currentFloor;
        }
        /**
         *  Output Passenger's status
         * */
        public void outStatus()
        {
            if (this.Status == 1)
            {
                Console.WriteLine("Waiting lift on the current floor");
            }
            if (this.Status == 2)
            {
                Console.WriteLine("in lift");
            }
            if (this.Status == 3)
            {
                Console.WriteLine("on the necessary floor");
            }
        }

       


    }
}
