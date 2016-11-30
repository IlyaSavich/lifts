using System.Collections;

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
