using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetChat.networkingDummy1
{
    public static class Extension
    {
        public static byte[] ToBytes(this object obj)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}