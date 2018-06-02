using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDataConnect
{
   public class GeneralQueryRunner
    {
        private string _schema;
        private string _connectionstring;
        public GeneralQueryRunner(string schema, string connectionstring)
        {
            _schema = schema;
            _connectionstring = connectionstring;
        }

       public void Run()
       {
           ExecuteQuery.Execute(_schema,_connectionstring);
       }


    }
}
