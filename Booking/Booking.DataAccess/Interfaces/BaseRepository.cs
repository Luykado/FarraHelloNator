using System.Data;
using Npgsql;

namespace Booking.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        private const string connectionString =
            "User ID=postgres;" +
            "Password=vivi123;" +
            "Host=localhost;" +
            "Port=5432;" +
            "Database=monobooking;";

        protected IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
