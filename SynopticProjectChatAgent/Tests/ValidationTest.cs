using NUnit.Framework;
using SynopticProjectChatAgent.Controllers;
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
            InputValidation inputValidator = new InputValidation();

            var input = "dfalksl";

            Assert.IsFalse(inputValidator.ValidateInput(input,filter.ContinentsList,"SelectContinent"));

        //act
        //assert

    }
    }
}
