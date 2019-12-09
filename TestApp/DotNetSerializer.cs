using System.IO;
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
            using (StreamWriter sr = new StreamWriter())
            {
                
            }
        }
    }
}