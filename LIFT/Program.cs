using System;
using System.Collections;
using System.Linq;
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
            Application.Run(new StartPage());
            /**/
            //LiftSystem.LiftSystem liftSystem = new LiftSystem.LiftSystem(5, 2);
            //Console.WriteLine("OK");
        }
    }
}
