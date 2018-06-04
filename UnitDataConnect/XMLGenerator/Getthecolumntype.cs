using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDataConnect.XMLGenerator
{
    public class Getthecolumntype
    {

        private string _tableName { get; set; }
        private string _conStr { get; set; }
        private string _dbname { get; set; }

        public Tablemodel columntypewriter(string tablename, string dbname, string connectionstring)
        {
            _dbname = dbname;
            _tableName = tablename;
            _conStr = connectionstring;
            Tablemodel datamodel = new Tablemodel();
            datamodel.tablename = tablename;

            IEnumerable<Tablemodel> col = GetColumnNames();

            return datamodel;
        }

        private List<Tablemodel> GetColumnNames()
        {



            List<Tablemodel> model=new List<Tablemodel>();
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("use " + _dbname + ";" + "select top 1 * from " + _tableName, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    Tablemodel data=new Tablemodel();
                    data.tablename = _tableName;
                    data.Columnname= reader.GetName(i);
                    data.Datatype=  reader.GetFieldType(i);
                    i++;
                    model.Add(data);
                }
            }
            return model;


        }




    }



    public class Tablemodel
    {
        public string tablename { get; set; }
        public string Columnname { get; set; }
        public Type Datatype { get; set; }
    }
}
