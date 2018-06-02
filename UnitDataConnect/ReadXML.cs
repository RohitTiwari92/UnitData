
using System.Collections.Generic;
using System.IO;

using System.Xml;


namespace UnitDataConnect
{
    public class ReadXML
    {
        

        public List<Dictionary<string,string>> Read(string path)
        {

            string data ;

            //var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(@path))
                                                         
            {
                data = streamReader.ReadToEnd();
            }
            List<Dictionary<string, string>> seeddata=new List<Dictionary<string, string>>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@path);
            XmlNodeList list = doc.DocumentElement.GetElementsByTagName("row");
            if (list.Count != 0)
            {

                for (int j = 0; j < list.Count; j++)
                {
                    Dictionary<string, string> rowdata = new Dictionary<string, string>();
                    for (int i = 0; i < list[j].ChildNodes.Count; i++)
                    {                       
                        XmlNode child = list[j].ChildNodes[i];
                        string s = child.Name;
                        string k = child.InnerText;
                        rowdata.Add(s,k);
                    }
                    seeddata.Add(rowdata);
                }
            }
            return seeddata;

        }
    }
}
