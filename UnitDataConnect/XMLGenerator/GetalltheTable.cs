using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace UnitDataConnect.XMLGenerator
{
 public   class GetalltheTable
    {
        public List<string> GettableList(string conString,string dbname)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(conString);
            builder.InitialCatalog = dbname;
            conString = builder.ConnectionString;
            List<string> list = new List<string>();

            // Open connection to the database


            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("use"+dbname+";SELECT name from sys.databases", con))
                {
                    //List<string> tables = new List<string>();
                    DataTable dt = con.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string tablename = (string)row[1]+"."+(string)row[2];
                        list.Add(tablename);
                    }
                    
                }
            }
            return list;

        }
    }
}
