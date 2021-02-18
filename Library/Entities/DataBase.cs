using System.Configuration;
using System.Data.SqlClient;

namespace Library.Entities
{
    public class DataBase
    {
        public static SqlConnection Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["KitchenSqlServer"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            
            return sqlConnection;
        }
    }
}