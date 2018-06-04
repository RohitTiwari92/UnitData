using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDataConnect
{
    public class CreateQuery
    {
        private readonly TableColumnandDataType _tableColumnandDataType = new TableColumnandDataType();

        public string create(string dbname, string tablename, List<Dictionary<string, string>> data, string sqlconnection,int datetymetype=105)
        {
            //,string sqlconnection
            var datatype = _tableColumnandDataType.GetDatatypeandColumn(dbname, tablename, sqlconnection);

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
                int i = 0;
                foreach (KeyValuePair<string, string> item in row)
                {
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        string   prefix = "convert(datetime,";
                        string suffix = ","+ datetymetype + ")";
                        if (value.Equals(""))
                        {
                            if (datatype[item.Key] == "datetime")
                            {
                                value = value + prefix+ "'" + item.Value + "'"+suffix;
                            }
                            else
                            {
                                value = value + "'" + item.Value + "'";
                            }
                             
                                             
                        }
                        else
                        {
                            if (datatype[item.Key] == "datetime")
                            {
                                value = value + ","+ prefix + "'" + item.Value + "'"+suffix;
                            }
                            else
                            {
                                value = value + ",'" + item.Value + "'";
                            }
                     
                            
                           
                        }



                        if (col.Equals(""))
                        {
                            col = col + item.Key;
                        }
                        else
                        {
                            col = col + "," + item.Key;
                        }
                    }
                     i++;
                }
                query = query + instable + col + close + val + value + close + ";";
            }
            return query;

        }
    }
}
