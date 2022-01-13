namespace SynopticProjectChatAgent.Helper
{
    public class FilterOptions
    {
        public List<string> ContinentsList = new List<string> 
        {
            "Asia","North America","Africa","Europe","Antarctica","South America","Australia"
        };

        public List<string> CategoryList = new List<string>
        {
           "active","lazy"
        };

        public List<string> LocationList = new List<string>
        {
            "sea","mountain","city"
        };

        public List<string> TempRatingList = new List<string>
        {
            "cold","mild","hot"
        };

    }
}
