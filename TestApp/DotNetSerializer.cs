using System.Runtime.Serialization;
using System.Xml;
using NCSharedlib;

namespace TestApp
{
    public static class DotNetSerializer
    {
        private static readonly DataContractSerializer serializer = new DataContractSerializer(typeof(User));

        public static void WriteToFile(User localUser)
        {
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            var xw = XmlWriter.Create(@"./data.xml", settings);
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