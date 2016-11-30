using System.Collections;

namespace LIFT.LiftSystem
{
    /**
     * This class works with system information. It resolve CRUD operations under system info
     */
    public class InformationRepository
    {
        /**
         * Dictionary that storing all info
         */
        protected static Hashtable Info = new Hashtable();

        /**
         * Replacing info by it key with new value or add new
         */
        public static void Update(string name, string value)
        {
            Info[name] = value;
        }

        /**
         * Get information by it name
         */
        public static string Get(string name)
        {
            return (string)Info[name];
        }

        /**
         * Getting full info stored in class
         */
        public static Hashtable GetFullInfo()
        {
            return Info;
        }
    }
}
