using System;
using System.Data;
using System.Data.SqlClient;

namespace Mag.Business.Repositories
{
    public class SqlRepositoryBase
    {
        public static DataContextDataContext DataContext { get; private set; }

        public SqlRepositoryBase(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            if (DataContext != null)
            {
                return;
            }

            IDbConnection connection = new SqlConnection(connectionString);
            DataContext = new DataContextDataContext(connection);
        }
    }
}