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
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartPage());*/

            /*InformationRepository.Update("name", "Jack");
            Console.WriteLine(InformationRepository.Get("name"));
            InformationRepository.Update("name", "John");
            Console.WriteLine(InformationRepository.Get("name"));
            InformationRepository.Update("id", "123");
            Console.WriteLine(InformationRepository.Add("id", 1));
            Console.WriteLine(InformationRepository.Add("name", 2));
            Console.WriteLine(InformationRepository.Add("price", 2));*/

            LiftSystem.LiftSystem liftSystem = new LiftSystem.LiftSystem(5, 2);
            liftSystem.Start();
            liftSystem.CreatePassenger(80, 3, 5);
            liftSystem.CreatePassenger(80, 2, 5);
            liftSystem.CreatePassenger(80, 1, 3);
            liftSystem.CreatePassenger(80, 4, 3);
            liftSystem.CreatePassenger(80, 5, 1);
            liftSystem.CreatePassenger(80, 1, 2);
            
            Thread.Sleep(4000);
            liftSystem.Stop();
            Thread.Sleep(6000);
            Console.WriteLine(InformationRepository.Get("trips_count"));
            Console.WriteLine(InformationRepository.Get("idle_trips_count"));
            Console.WriteLine(InformationRepository.Get("total_moved_weight"));
            Console.WriteLine(InformationRepository.Get("created_passengers_count"));
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
