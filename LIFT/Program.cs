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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            
            InformationRepository.Update("name","Vasya");
            Console.WriteLine(InformationRepository.Get("name"));
            InformationRepository.Update("name", "Petya");
            Hashtable fullInfo = InformationRepository.GetFullInfo();
            ICollection a = fullInfo.Keys;
            foreach (string s in a)
                Console.WriteLine(s + ": " + fullInfo[s]);
            Console.ReadLine();

        }
    }
}
