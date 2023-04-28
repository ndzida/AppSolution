using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataManagement
{
    public class CrudActions
    {
        private SqlConnection connection;
        public CrudActions(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public DataSet SelectActionWithResult(string command, CommandType commandType)
        {
            using (SqlConnection con = connection)
            {
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
