using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDataConnect;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string conn = UnitData.GetConnectionString();
            UnitData.CreatDatabase(
                @"D:\Test Data\db.sql", conn, @"D:\temp", "Test");
            UnitData.SeedTable("Test", "tablename", @"D:\PBIs\apietest\rohit.xml", conn);
        }


    }
}
