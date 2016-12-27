using System;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIFT.LiftSystem;

namespace LIFT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartPage());/**/

            /*LiftSystem.LiftSystem liftSystem = new LiftSystem.LiftSystem(5, 2);
            liftSystem.Start();
            liftSystem.CreatePassenger(80, 1, 5);
            Console.WriteLine(liftSystem.PassengerStatus(1));
            liftSystem.CreatePassenger(80, 2, 5);
            Console.WriteLine(liftSystem.PassengerStatus(1));
            liftSystem.CreatePassenger(80, 1, 3);
            Console.WriteLine(liftSystem.PassengerStatus(1));
            liftSystem.CreatePassenger(80, 4, 3);
            Console.WriteLine(liftSystem.PassengerStatus(1));
            liftSystem.CreatePassenger(80, 5, 1);
            Console.WriteLine(liftSystem.PassengerStatus(1));
            liftSystem.CreatePassenger(80, 1, 2);
            Console.WriteLine(liftSystem.PassengerStatus(1));

            Thread.Sleep(4000);
            Console.WriteLine(liftSystem.PassengerStatus(1));
            liftSystem.Stop();
            Console.WriteLine(liftSystem.PassengerStatus(1));
            Thread.Sleep(6000);
            Console.WriteLine(liftSystem.PassengerStatus(1));
            Thread.Sleep(Timeout.Infinite);/**/
        }
    }
}
