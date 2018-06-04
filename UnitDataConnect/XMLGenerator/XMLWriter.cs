using System.IO;
using System.Xml;

namespace UnitDataConnect.XMLGenerator
{
    public class XMLWriter
    {
        public void Write(XMLmodel model, string dbname,string tablename, string dirpath,string prefix="")
        {
            string filename = dirpath + @"\" +"Data_"+ prefix + "_" + dbname + "_" + tablename + ".xml";
            //File.Create(filename);
            GenerateFile(model,filename);

        }


        private void GenerateFile(XMLmodel data,string filepath)
        {
            XmlTextWriter writer = new XmlTextWriter(filepath, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Data");
            createNode(writer,data);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void createNode( XmlTextWriter writer,XMLmodel data)
        {
            
            foreach (var rows in data.Data)
            {
                writer.WriteStartElement("row");
                for (int i = 0; i < rows.Count; i++)
                {
                    writer.WriteStartElement(data.Columnname[i]);
                    writer.WriteString(rows[i]);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        
         
        }
    }
}
