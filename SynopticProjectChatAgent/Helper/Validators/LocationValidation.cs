using SynopticProjectChatAgent.Helper;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;


namespace SynopticProjectChatAgent
{
    public class LocationValidation : ValidationAttribute 
    {
        FilterOptions filter = new FilterOptions();


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string input = value.ToString();
            if (value != null)
            {
                if (filter.LocationList.Contains(value))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Invalid Location");
        }
        }
}
