using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Demo.NewtonsoftJson
{
    public class DeviceRepository: JsonRepository
    {
        public static JObject CreateDeviceJsonObject(Device device)
        {
            return JObject.FromObject(
                new
                {
                    device.Name,
                    device.IpAddress,
                    device.Port,
                    MediaList = device.MediaList.Select(
                        m => new
                        {
                            m.Name,
                            m.Path
                        })
                });
        }
    }
}
