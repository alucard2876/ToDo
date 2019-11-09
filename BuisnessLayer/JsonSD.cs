using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace BuisnessLayer
{
    public static class JsonSD
    {
        public static T Desirialize<T>(string path) where T : class
        {
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    var str = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(str);
                }
            }
            return null;
        }
        public static void Serialize<T>(T obj, string path) where T : class
        {
            if (File.Exists(path))
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.WriteAsync(JsonConvert.SerializeObject(obj));
                }
            }
        }
    }
}
