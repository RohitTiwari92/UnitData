using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace UnitDataConnect.XMLGenerator
{
    public class GetTheDataFromTable
    {
        private string _tableName { get; set; }
        private string _conStr { get; set; }
        private string _dbname { get; set; }

        public XMLmodel Getdata(string tablename, string dbname, string connectionstring)
        {
            _dbname = dbname;
            _tableName = tablename;
            _conStr = connectionstring;
            XMLmodel datamodel = new XMLmodel();
            datamodel.tablename = tablename;

            IEnumerable<string> col = GetColumnNames();
            GetTableData(col, datamodel);
            return datamodel;
        }

        private IEnumerable<string> GetColumnNames()
        {
            var result = new List<string>();
            using (var sqlCon = new SqlConnection(_conStr))
            {
                try
                {


                    sqlCon.Open();
                    var sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandText = "use " + _dbname + ";select * from " + _tableName + " where 1=0";
                    // No data wanted, only schema
                    sqlCmd.CommandType = CommandType.Text;

                    var sqlDR = sqlCmd.ExecuteReader();
                    var dataTable = sqlDR.GetSchemaTable();

                    foreach (DataRow row in dataTable.Rows) result.Add(row.Field<string>("ColumnName"));
                }
                catch (Exception)
                {

                    //throw;
                }
            }

            return result;
        }

        private void GetTableData(IEnumerable<string> col, XMLmodel datamodel)
        {
            var result = new List<string>();
            string column = "";

            string conString = _conStr;

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("use " + _dbname + ";SELECT top 5  * from " + _tableName, con))
                {
                    try
                    {


                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            for (int i = 0; i < col.Count(); i++)
                            {
                                column = Convert.ToString(col.ElementAt(i));
                                datamodel.Columnname.Add(column);

                            }
                            while (dr.Read())
                            {
                                List<string> data = new List<string>();
                                for (int i = 0; i < col.Count(); i++)
                                {

                                    // column = ","+column + Convert.ToString(col.ElementAt(i));
                                    data.Add(Convert.ToString(dr[datamodel.Columnname[i]]));

                                }
                                datamodel.Data.Add(data);
                            }
                        }
                    }
                    catch (Exception)
                    {

                        //   throw;
                    }
                }
            }


        }

    }

    public class XMLmodel
    {
        public string tablename { get; set; }
        public List<string> Columnname = new List<string>();
        public List<List<string>> Data = new List<List<string>>();
    }
}
