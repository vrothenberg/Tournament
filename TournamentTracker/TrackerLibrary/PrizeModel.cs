using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// Represents the ranking for the prize.
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// Represents the title of the prize.
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// Represents the monetary value of the prize.
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// Represents the monetary value as a percentage of entry fees.  
        /// </summary>
        public double PrizePercentage { get; set; }

    }
}
