using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace FitnessCenter.Web.Utilities
{
    public static class Extensions
    {
        public static T GetObject<T>(this ISession session, string key)
        {
            var json = session.GetString(key);

            return string.IsNullOrEmpty(json) ? default : JsonConvert.DeserializeObject<T>(json);
        }

        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static void SetObject<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T GetObject<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out var o);

            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        public static bool HasKey(this ISession session, string key)
        {
            return session.Keys.Contains(key);
        }
    }
}
