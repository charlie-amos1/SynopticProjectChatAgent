using NUnit.Framework;
using SynopticProjectChatAgent.Data;
using SynopticProjectChatAgent.Models;

namespace SynopticProjectChatAgent.Tests
{
    public class StoredProcedureTest
    {
        [Test]
        public void Stored_Procedure_is_Called()
        {
            DataConnection connection = new DataConnection();
            //arrange

             string tempRating = "mild";

             string continent= "Asia";


             string category="active";


             string location="city";

        //expected
        List<Holiday> expectedResults = new List<Holiday>()
            {
                new Holiday{ Category = category,TempRating=tempRating,Continent=continent,
                 Location=location}
            };
            //act
            var actualResult = connection.GetFilteredHolidays(expectedResults,continent,category,location,tempRating);

            //assert        

            Assert.AreEqual(expectedResults, actualResult);
        }
    }
}
