using System.IO;
using System.Reflection.Emit;
using Newtonsoft.Json;
namespace NCSharedlib
{
    /// <summary>
    /// manager to save all data to a local File
    /// </summary>
    public static class MemoryManager
    {
        /// <summary>
        /// Write all the informaiton of the localUser to a File
        /// </summary>
        /// <param name="localUser"></param>
        public static void WriteToFile(User localUser)
        {
            
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sr = new StreamWriter(@"./data.json"))
            {
                serializer.Serialize(sr, localUser);
            }
        }

        /// <summary>
        /// Read the local User and his information from a file
        /// </summary>
        /// <returns>User Object</returns>
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