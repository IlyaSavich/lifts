using System;
using System.Collections.Generic;
using System.Data;
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
        protected bool[,] Buttons;

        /**
         * The array of passengers from all floors
         */
        protected List<Passenger.Passenger>[] Passengers;

        /**
         * The array of lifts setting in the building
         */
        protected Lift.Lift[] Lifts;

        /**
         * Threads of the lifts
         */
        protected Thread[] LiftsThreads;

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
            FloorsCount = floorsCount;
            LiftsCount = liftsCount;

            Passengers = new List<Passenger.Passenger>[floorsCount];
            Lifts = new Lift.Lift[liftsCount];
            LiftsThreads = new Thread[liftsCount];
            Buttons = new bool[floorsCount, liftsCount];

            InitLifts();
        }

        /**
         * Init rub thread method for each lift. Starting threads
         */

        protected void InitLifts()
        {
            for (int i = 0; i < Lifts.Length; i++)
            {
                Lifts[i] = new Lift.Lift(FloorsCount);

                try
                {
                    LiftsThreads[i] = new Thread(Lifts[i].Run);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    System.Environment.Exit(1);
                }
                LiftsThreads[i].Start();
            }
        }

        /**
         * Set button enabled on selected floor and select to specific lift
         */
        public void PressButton(Passenger.Passenger passenger)
        {
            if (passenger.NecessaryFloor > this.FloorsCount)
            {
                throw new InvalidExpressionException("The selected floor is invalid: " + passenger.NecessaryFloor);
            }

            if (passenger.LiftNumber < 0 || passenger.LiftNumber > this.LiftsCount)
            {
                throw new InvalidExpressionException("The selected lift is invalid: " + passenger.LiftNumber);
            }
            Buttons[passenger.NecessaryFloor, passenger.LiftNumber] = true;

            Lifts[passenger.CurrentFloor].Call(passenger.CurrentFloor);
        }

        /**
         * Adding passenger to floor
         */
        public void AddPassenger(Passenger.Passenger passenger)
        {
            Passengers[passenger.CurrentFloor].Add(passenger);
        }
    }
}