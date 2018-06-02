using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDataConnect
{
  public class CreateQuery
    {
      public string create(string dbname, string tablename, List<Dictionary<string, string>> data)
      {

          string query = "";
          string usest = "use " + dbname + ";";
          string instable = "INSERT INTO  " + tablename + " (";
          string val = "values (";
          string close = ")";
          query = usest;
          foreach (Dictionary<string, string> row in data)
          {
              string col = "";
              string value = "";
              foreach (KeyValuePair<string, string> item in row)
              {
                  if (col.Equals(""))
                  {
                      col = col + item.Key;
                  }
                  else
                  {
                      col = col + "," + item.Key;
                  }
                  if (value.Equals(""))
                  {
                      value = value + "'" + item.Value + "'";
                  }
                  else
                  {
                      value = value + ",'" + item.Value + "'";
                  }

              }
              query = query + instable + col + close + val +value+ close + ";";
          }
          return query;

      }
    }
}
