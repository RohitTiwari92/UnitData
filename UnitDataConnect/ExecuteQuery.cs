using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDataConnect
{
   public static class ExecuteQuery
    {
       public static void Execute(string query, string connstr)
       {
            using (SqlConnection conn = new SqlConnection(connstr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
