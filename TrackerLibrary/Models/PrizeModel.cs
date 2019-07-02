using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifier for the prize.
        /// </summary>
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmt, string prizePercnt)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmtValue = 0;
            decimal.TryParse(prizeAmt, out prizeAmtValue);
            PrizeAmount = prizeAmtValue;

            double prizePercntValue = 0;
            double.TryParse(prizePercnt, out prizePercntValue);
            PrizePercentage = prizePercntValue;
        }
    }
}
