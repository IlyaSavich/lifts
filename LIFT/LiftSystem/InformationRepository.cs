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
            {"total_moved_weight", "Total moved weight"},
            {"passengers_count", "Passengers count"},
            {"trips_count", "Trips count"},
            {"idle_trips_count", "Idle trips count"}
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

        public static void PrintWord(string path = @"c:\lift.docx")
        {
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

            //Create a missing variable for missing value
            object missing = System.Reflection.Missing.Value;

            //Create a new document
            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing,
                ref missing, ref missing);

            document.Content.SetRange(0, 0);
            document.Content.Text = OutInfo();

            object filename = path;
            document.SaveAs2(ref filename);
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;
        }

        public static void PrintExcel(string path = @"c:\lift.xls")
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;
            var xlWorkBook = xlApp.Workbooks.Add(missing);

            //Create a new document
            var document = (Microsoft.Office.Interop.Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);

            document.Cells[1, 1] = InfoNames["total_moved_weight"];
            document.Cells[1, 2] = Get("total_moved_weight");
            document.Cells[2, 1] = InfoNames["passengers_count"];
            document.Cells[2, 2] = Get("passengers_count");
            document.Cells[3, 1] = InfoNames["trips_count"];
            document.Cells[3, 2] = Get("trips_count");
            document.Cells[4, 1] = InfoNames["idle_trips_count"];
            document.Cells[4, 2] = Get("idle_trips_count");

            xlWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
            xlWorkBook.Close(true, missing, missing);
            xlApp.Quit();
        }
    }
}