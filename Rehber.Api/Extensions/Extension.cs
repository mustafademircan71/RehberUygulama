using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.Api.Extensions
{
    public static class Extension
    {
        public static void SetObjcet(this ISession session, string key, object value)
        {
            string jsonObject = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonObject);
        }
        public static T GetObject<T>(this ISession session, string key)
            where T : class
        {
            string jsonObject = session.GetString(key);

            if (!string.IsNullOrEmpty(jsonObject))
            {
                return JsonConvert.DeserializeObject<T>(jsonObject);
            }
            return null;
        }
    }
}
