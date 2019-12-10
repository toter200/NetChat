using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using NCSharedlib;

namespace TestApp
{
    public static class DotNetSerializer
    {
        private static  DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(User));

        //TODO:
        //implement DataContractJsonSerilizer
        public static void WriteToFile(User localUser)
        {
            StreamWriter sw = new StreamWriter(@"./data.json");
            
            serializer.WriteObject(sw.BaseStream, localUser);
        }

        public static User ReadFromFile()
        {
            User localUser;
            using (StreamReader sr = new StreamReader(@"./data.json"))
            {
                localUser = (User) serializer.ReadObject(sr.BaseStream);
            }

            return localUser;
        } 
    }
}