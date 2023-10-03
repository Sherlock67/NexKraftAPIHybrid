using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Oracle
{
    public class OracleDbConnection:IDisposable
    {
        public OracleConnection Connection { get; }

        public OracleDbConnection(string connectionString)
        {
            Connection = new OracleConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
