using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDataConnect
{
   public static class UnitData
    {
        public static string GetConnectionString()
       {
            string connStr= System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            return connStr;
       }

       public static void CreatDatabase(string schemaFilePath, string connectionString, string location, string dbname)
       {
            Createdatabase cdb=new Createdatabase(schemaFilePath, connectionString);
            cdb.Create(location, dbname);
       }
        public static void SeedTable(string dbName, string tableName, string seedFilePath, string connectionString)
        {
           SeedTables sdt=new SeedTables();
            sdt.SeedTable(dbName, tableName, seedFilePath, connectionString);
        }

        public static void DeleteDb(string dbName, string connectionString)
        {
            DeleteDatabase ddb = new DeleteDatabase(dbName, connectionString);
            ddb.Delete();
        }

        public static void RunGeneralQuery( string connectionString,string query)
        {
            GeneralQueryRunner ddb = new GeneralQueryRunner(query, connectionString);
            ddb.Run();
        }
    }
}
