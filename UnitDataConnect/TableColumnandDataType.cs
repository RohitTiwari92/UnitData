using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnitDataConnect
{
    public class TableColumnandDataType
    {
        public Dictionary<string, string> GetDatatypeandColumn(string dbname, string tablename, string sqlconnection)
        {
            Dictionary<string, string> datatype = new Dictionary<string, string>();
            using (SqlConnection connection = new SqlConnection(
                sqlconnection))
            {
                connection.Open();

                SqlCommand command =
                    new SqlCommand(
                        "use " + dbname + ";" +
                        " SELECT column_name , data_type FROM information_schema.columns WHERE table_name = '" + tablename + "'",
                        connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datatype.Add(reader.GetString(0), reader.GetString(1));
                }
            }
            return datatype;
        }
    }
}