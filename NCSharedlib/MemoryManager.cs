using System.IO;
using System.Reflection.Emit;
using Newtonsoft.Json;
namespace NCSharedlib
{
    public static class MemoryManager
    {
        public static void WriteToFile(User localUser)
        {
            
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sr = new StreamWriter(@"./data.json"))
            {
                serializer.Serialize(sr, localUser);
            }
        }

        public static User ReadFormFile()
        {
            User localUser;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(@"./data.json"))
            {
                localUser = (User) serializer.Deserialize(sr, typeof(User));
            }

            return localUser;
        }
    }
}