using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using NCSharedlib;

namespace TestApp
{
    public static class DotNetSerializer
    {
        private static  DataContractSerializer serializer = new DataContractSerializer(typeof(User));

        //TODO:
        //implement DataContractJsonSerilizer
        public static void WriteToFile(User localUser)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter xw = XmlWriter.Create(@"./data.xml", settings);
            serializer.WriteObject(xw, localUser);
            
            xw.Flush();
            xw.Close();
        }

        public static User ReadFromFile()
        {
            User localUser;
            
            XmlReader xr = new XmlTextReader(@"./data.xml");

            localUser = (User) serializer.ReadObject(xr);
            xr.Close();
            return localUser;
        } 
    }
}