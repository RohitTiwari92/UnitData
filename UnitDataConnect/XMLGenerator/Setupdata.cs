using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDataConnect.XMLGenerator;
namespace UnitDataConnect.XMLGenerator
{
  public   class Setupdata
    {
      public void Setup(string dbname, string dirpath, string connectionstring, string prefix = "")
      {
          GetalltheTable tableobj=new GetalltheTable();
          List<string> tablesList = tableobj.GettableList(connectionstring);
            Createtable ct = new Createtable();
            ct.Write(dbname,  dirpath, connectionstring, prefix);
            foreach (var table in tablesList)
          {
              
              GetTheDataFromTable dtDataFromTable=new GetTheDataFromTable();
              XMLmodel model = dtDataFromTable.Getdata(table, dbname, connectionstring);
              XMLWriter wrobj=new XMLWriter();
              wrobj.Write(model,dbname,table,dirpath,prefix);
          }
      }
    }
}
