using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDataConnect;
using UnitDataConnect.XMLGenerator;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string conn = UnitData.GetConnectionString();//this will give you your app.config connection string 
            UnitData.CreatDatabase(@"D:\Test Data\db.sql", conn, @"D:\temp", "Test"); // sql file for tables , sp and whatever you want to put in the database
            UnitData.DataSetup("Test", @"D:\temp\TEst", "Data Source=0.0.0.0;Initial Catalog=Test;User Id=sqlTest;Password=Manager@TEST;", "Test");// this method for data setup this method will give you xml files for data seed and create table file.
            UnitData.SeedTable("Test", "tablename", @"D:\Test\table.xml", conn); // this method used for seeding the table 
         }
    }
}
