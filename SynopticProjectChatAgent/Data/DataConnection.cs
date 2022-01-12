using Dapper;
using SynopticProjectChatAgent.Models;
using System.Data;
using System.Data.SqlClient;

namespace SynopticProjectChatAgent.Data
{
    public class DataConnection
    {
        string _connectionString = "Data Source=.;Initial Catalog=ProjectCDatabase;Integrated Security=True";


        public List<Holiday> GetFilteredHolidays(List<Holiday> recordscreated, string continent, string category, string location, string tempRating)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                recordscreated = connection.Query<Holiday>("HolidayFilter", new { Continent = continent, Category = category, Location = location, TempRating=tempRating },
                    commandType: CommandType.StoredProcedure).ToList();

            }

            return recordscreated;
        }

        public List<Holiday> GetAllHolidays(List<Holiday> createdRecords)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //recordscreated = connection.Query<Holiday>("SelectAll", commandType: CommandType.StoredProcedure).ToList();
                createdRecords = connection.Query<Holiday>("Select * From [Dbo].[Holiday]").ToList();

            }
            return createdRecords;
        }
    }
}
