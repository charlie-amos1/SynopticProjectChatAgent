using System.ComponentModel.DataAnnotations;

namespace SynopticProjectChatAgent.Models
{
    public class UiHolidayFilters
    {
        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Invalid Input")]
        [TempRatingValidation]
        public string TempRating { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Invalid Input")]
        [ContinentValidation()]
        public string Continent { get; set; }


        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Invalid Input")]
        [CategoryValidation()]
        public string Category { get; set; }


        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Invalid Input")]
        [ContinentValidation()]
        public string Location { get; set; }

    }
}
