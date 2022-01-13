namespace SynopticProjectChatAgent.FilterModels
{
    public class FilterOptions
    {
        public List<string> CategoryChoices = new List<string>()
        {
            "Lazy", "Active"
        };

        public List<string> ContinentChoices = new List<string>()
        {
            "North America",
        "Europe",
        "Asia",
         "Australia",
        "Antarctica",
        "Arctic",
        "Africa",
        };

        public List<string> LocationChoices = new List<string>()
        {
            "City",
            "Sea",
            "mountain"

        };

        public List<string> TemperatureOptions = new List<string>()
        {
            "Mild",
            "Hot",
            "Cold"
        };
    }
};
