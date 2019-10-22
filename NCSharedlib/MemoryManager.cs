using System.IO;
using Newtonsoft.Json;
namespace NCSharedlib
{
    public static class MemoryManager
    {
        public static void WriteToFile(User localUser)
        {
            
            JsonSerializer serializer = new JsonSerializer();
            
            using (StreamWriter sw = new StreamWriter(@"./data.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, localUser);
            }
        }

        public static void ReadFromFile()
        {
            
        }
    }
}