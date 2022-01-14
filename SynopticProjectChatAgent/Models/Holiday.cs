using System.ComponentModel.DataAnnotations;

namespace SynopticProjectChatAgent.Models
{
    public class Holiday
    {
        //each model represents a column from the database/aspect of the holiday
        public int HoliidayReference { get; set; }

        public string  HotelName { get; set; }

        public string TempRating { get; set; }


        public string Continent { get; set; }

        public string Country { get; set; }

        public string Category { get; set; }

        public int StarRating { get; set; }

        public string Location { get; set; }

        public decimal PricePerNight { get; set; }

        //helps with testing
        public bool Equals(Holiday other)
        {
            if (Continent != other.Continent)
            {
                return false;
            }
            if (Country != other.Country)
            {
                return false;
            }
            if (Category != other.Category)
            {
                return false;
            }
            if (TempRating != other.TempRating)
            {
                return false;
            }
            if (Location != other.Location)
            {
                return false;
            }
           
            return true;
        }
    }
}
