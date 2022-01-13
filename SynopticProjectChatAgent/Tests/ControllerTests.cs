using NUnit.Framework;
using SynopticProjectChatAgent.Data;
using SynopticProjectChatAgent.FilterModels;
using SynopticProjectChatAgent.Helper;
using SynopticProjectChatAgent.Models;
namespace SynopticProjectChatAgent.Tests
{
    public class ControllerTests
    {
        [Test]
        public void Matching_Input_Should_Return_True() 
        {

            //arrange
            FilterOptions list = new FilterOptions();
            StringInputValidator validator = new StringInputValidator();
            var mild = "Mild";
            //act

            //assert
            Assert.IsTrue(validator.CheckForValidInputs(list.TemperatureOptions, mild));
        }

    }
}
