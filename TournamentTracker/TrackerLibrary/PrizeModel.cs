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
        /// The title of the prize e.g. 'First runner up'.
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// The monetary value of the prize.
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// The monetary value of the prize as a percentage of entry fees.  
        /// </summary>
        public double PrizePercentage { get; set; }

    }
}
