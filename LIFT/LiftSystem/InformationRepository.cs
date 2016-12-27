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
        public static readonly Hashtable InfoNames = new Hashtable()
        {
            {"total_moved_weight", "Total moved weight" },
            {"passengers_count", "Passengers count" },
            {"trips_count", "Trips count" },
            {"idle_trips_count", "Idle trips count" }
        };

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

        public static string OutInfo()
        {
            string output = "";
            output += InfoNames["total_moved_weight"] + ": " + Get("total_moved_weight") + "\n";
            output += InfoNames["passengers_count"] + ": " + Get("passengers_count") + "\n";
            output += InfoNames["trips_count"] + ": " + Get("trips_count") + "\n";
            output += InfoNames["idle_trips_count"] + ": " + Get("idle_trips_count") + "\n";

            return output;
        }
    }
}