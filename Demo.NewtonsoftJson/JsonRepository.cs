using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Demo.NewtonsoftJson
{
    public abstract class JsonRepository
    {
        public static JObject CreateJsonObject<T>(T t, Func<T, object> selectProperty)
        {
            return JObject.FromObject(
                selectProperty(t));
        }
    }
}
