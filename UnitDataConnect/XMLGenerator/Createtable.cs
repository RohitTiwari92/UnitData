using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDataConnect.XMLGenerator
{
   public class Createtable
    {
        public void Write( string dbname, string dirpath, string connectionstring, string prefix = "")
        {
            
           // File.Create(filename);
            TableScript scriptobj = new TableScript(dbname,connectionstring);
            Dictionary<string,string> scripts = scriptobj.Createscript();
            foreach (var script in scripts)
            {
                string filename = dirpath + @"\" + "table_" + prefix + "_" + dbname + "_" + script.Key + ".sql";
                using (StreamWriter writerobj = new StreamWriter(filename))
                {
                    writerobj.Write(script.Value);
                }
            }
           
        }

    }
}
