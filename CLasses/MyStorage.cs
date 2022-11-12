using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp1
{
    public class MyStorage
    {
        internal static void WriteXml<T>(T data, string fileName)
        {
            XmlSerializer srz = new XmlSerializer(typeof(T));
            FileStream stream;

            stream = new FileStream(fileName, FileMode.Create);
            srz.Serialize(stream, data);
            stream.Close();
            //throw new NotImplementedException();
        }
        internal static T ReadXML<T>(string fileNames)
        {
            XmlSerializer srz = new XmlSerializer(typeof(T));
            try
            {
                using (StreamReader sr = new StreamReader(fileNames))
                    return (T)srz.Deserialize(sr);
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message, "Error....");
                return default(T);
            }
        }
    }
}