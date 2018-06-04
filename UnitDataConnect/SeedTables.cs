using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDataConnect
{
    public class SeedTables
    {
        public void SeedTable(string dbname, string tablename, string Filepath, string connectionsting, int datetymetype = 105)
        {
            ReadXML xmlreaer = new ReadXML();
            List<Dictionary<string, string>> data = xmlreaer.Read(Filepath);
            CreateQuery queryobj = new CreateQuery();
            string query = queryobj.create(dbname, tablename, data, connectionsting, datetymetype );
            ExecuteQuery.Execute(query, connectionsting);
        }
    }

}
