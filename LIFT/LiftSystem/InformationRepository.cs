using System;
using System.Collections;
using System.IO;

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

        public static bool Add(string name, int addValue)
        {
            try
            {
                int newValue = int.Parse(Get(name)) + addValue;
                Update(name, newValue.ToString());
            }
            catch (ArgumentNullException e)
            {
                int newValue = 0 + addValue;
                Update(name, newValue.ToString());
            }
            catch (FormatException e)
            {
                return false;
            }

            return true;
        }

        public static bool Increment(string name)
        {
            return Add(name, 1);
        }

        /**
         * Get information by it name
         */

        public static string Get(string name)
        {
            if (Has(name))
            {
                return Info[name].ToString();
            }

            return null;
        }

        public static bool Has(string name)
        {
            return Info.Contains(name);
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