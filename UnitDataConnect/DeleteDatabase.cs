using System;
using System.Data.SqlClient;

namespace UnitDataConnect
{
    public class DeleteDatabase
    {
        private readonly string _dbname;
        private readonly string _connectionstring;

        public DeleteDatabase(string dbname, string connectionstring)
        {
            _dbname = dbname;
            _connectionstring = connectionstring;
        }

        public void Delete()
        {          
                String sqlCommandText = @"
                ALTER DATABASE " + _dbname + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                DROP DATABASE [" + _dbname + "]";
              ExecuteQuery.Execute(sqlCommandText,_connectionstring);
        }
    }
}
