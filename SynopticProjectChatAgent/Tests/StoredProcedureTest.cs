using NUnit.Framework;
using SynopticProjectChatAgent.Data;
using SynopticProjectChatAgent.Models;

namespace SynopticProjectChatAgent.Tests
{
    public class StoredProcedureTest
    {
        [Test]
        private void Stored_Procedure_is_Called()
        {
            DataConnection connection = new DataConnection();
            //arrange
             string hotelName= "TechCity";

             string tempRating = "mild";

             string continent= "Asia";

             string country="Japan";

             string category="active";

             int starRating= 3;

             string location="city";

             decimal pricePerNight=71; 

        //expected
        List<Holiday> expectedResults = new List<Holiday>()
            {
                new Holiday{ Category = category,HotelName= hotelName,TempRating=tempRating,Continent=continent,Country=country,
                    StarRating=starRating,Location=location,PricePerNight=pricePerNight }
            };
            //act
            var actualResult = connection.GetFilteredHolidays(expectedResults,continent,category,location,tempRating);

            //assert        

            Assert.AreEqual(expectedResults, actualResult);
        }
    }
}
