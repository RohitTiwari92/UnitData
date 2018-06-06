using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;



namespace UnitDataConnect
{
    public class Createdatabase
    {
        private string _schemas;
        private string _connectionstring;


        public Createdatabase(string schemas, string connectionstring)
        {
            _schemas = schemas;
            _connectionstring = connectionstring;

        }

        public void Create(string location, string dbname)
        {
            createDatabase(location, dbname);
            SqlConnectionStringBuilder builder=new SqlConnectionStringBuilder(_connectionstring);
            builder.InitialCatalog = dbname;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                
                SqlCommand cmd = new SqlCommand();
                
                    string script = File.ReadAllText(@_schemas);
                    cmd.CommandText = script;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.ExecuteReader();
                    connection.Close();
                
            }
        }

        void createDatabase(string location, string dbname)
        {
            String CreateDatabase;
            SqlConnection connection =
                new SqlConnection(_connectionstring);
            CreateDatabase = "CREATE DATABASE " + dbname + " " +
                             "ON PRIMARY " +
                             "(NAME = '" + dbname + "', " +
                             "FILENAME = '" + location + dbname+".mdf', " +
                             "SIZE = 6MB, MAXSIZE = 50GB, FILEGROWTH = 10%) " +
                             "LOG ON " +
                             "(NAME = '" + dbname + "_LOG" + "', " +
                             "FILENAME = '" + location + dbname + ".ldf', " +
                             "SIZE = 1MB, MAXSIZE = 200MB, FILEGROWTH = 10%)" +
                             "";

            SqlCommand command = new SqlCommand(CreateDatabase, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
