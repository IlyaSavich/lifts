using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFT.LiftSystem
{
    /**
     * This class works with all system as intermediary between GUI and system
     */
    public class ListSystem
    {
        /**
         * Wrapper method for getting full info
         */
        public Hashtable GetFullInfo()
        {
            return InformationRepository.GetFullInfo();
        }
    }
}
