using System;
using System.Data;
using System.Data.SqlClient;

using log4net;

namespace Mag.Business.Repositories
{
    public class SqlRepositoryBase
    {
        public static DataContextDataContext DataContext { get; private set; }

        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SqlRepositoryBase(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                Log.Error("Can't create SqlRepositoryBase because connectionString is empty");
                throw new ArgumentNullException("connectionString");
            }

            if (DataContext != null)
            {
                return;
            }

            try
            {
                IDbConnection connection = new SqlConnection(connectionString);
                DataContext = new DataContextDataContext(connection);
            }
            catch (Exception exc)
            {
                Log.Error(string.Format("Can't create SqlRepositoryBase. Connectionstring={0}", connectionString), exc);
                throw;
            }
            
        }
    }
}