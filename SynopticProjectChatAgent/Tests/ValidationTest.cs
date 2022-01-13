using NUnit.Framework;
using SynopticProjectChatAgent.Helper;
using SynopticProjectChatAgent.Validators;
using System.ComponentModel.DataAnnotations;

namespace SynopticProjectChatAgent.Tests
{
    public class ValidationTest
    {
        [Test]
        public void Validator_is_accepts_correct_answerr() 
        {
            //arrange
            FilterOptions filter = new FilterOptions();
            ContinentValidation continentValidator = new ContinentValidation();

            var input = "dfalksl";

            Assert.AreEqual(new ValidationResult("Not A Valid Continent"),continentValidator.IsValid(input));

        //act
        //assert

    }
    }
}
