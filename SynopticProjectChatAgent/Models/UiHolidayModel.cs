using System.ComponentModel.DataAnnotations;

namespace SynopticProjectChatAgent.Models
{
    public class UiHolidayModel
    {

        public string TempRating { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Invalid Input")]
        public string Continent { get; set; }
        public string Location { get; set; }

        public string Category { get; set; }

    }
}
