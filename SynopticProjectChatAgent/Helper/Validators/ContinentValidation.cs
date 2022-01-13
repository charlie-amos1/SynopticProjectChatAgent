using SynopticProjectChatAgent.Helper;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;


namespace SynopticProjectChatAgent
{
    public class ContinentValidation : ValidationAttribute 
    {
        FilterOptions filter = new FilterOptions();


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string input = value.ToString();
            if (value != null)
            {
                if (filter.ContinentsList.Contains(value))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Invalid Continent");
        }

        }
}
