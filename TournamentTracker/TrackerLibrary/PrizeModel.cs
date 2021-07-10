using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifier for the prize.
        /// </summary>
        public int Id { get; set; }
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

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;
            
            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;



        }


    }
}
