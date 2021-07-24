using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.DataAccess.Interfaces;
using Booking.DataAccess.Models;
using Dapper;

namespace Booking.DataAccess.Repositories
{
    public class RecordRepository : BaseRepository, IRecordRepository
    {
        private const string CreateQuery = "SELECT InsertRecord(@Date, @Status, @Deleted, @CreatedDate, @LastModifiedDate);";

        public async Task<int> CreateAsync(Record record)
        {
            try
            {
                using(var connection = CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Date", record.Date, System.Data.DbType.DateTime);
                    parameters.Add("Status", record.Status, System.Data.DbType.Int32);
                    parameters.Add("Deleted", record.Deleted, System.Data.DbType.Boolean);
                    parameters.Add("CreatedDate", record.CreatedDate, System.Data.DbType.DateTime);
                    parameters.Add("LastModifiedDate", record.LastModifiedDate, System.Data.DbType.DateTime);

                    return await connection.QuerySingleAsync<int>(CreateQuery, parameters);
                }
            }
            catch(Exception)
            {
                return -1;
            }
        }
    }
}
