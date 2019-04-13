using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo.NewtonsoftJson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Image> images = new List<Image>
            {
                new Image {Path = "D://"},
                new Image {Path = "E:"},
                new Image {Path = "F:"}
            };
            List<Device> devices = new List<Device>
            {
                new Device("device1", "127.0.0.1", images),
                new Device("device2", "127.0.0.1", images)
            };
            Device de = new Device("device3", "127.0.0.1", images);
            JObject deviceList = new JObject(new JProperty(
                "Devices",new JArray(
                    devices.Select(d => new JObject(
                            new JProperty("Name",d.Name),
                            new JProperty("IPAddress",d.IpAddress),
                            new JProperty("Port",d.Port),
                            new JProperty("MediaList", new JArray(
                                d.MediaList.Select(m => new JObject(
                                    new JProperty("Name",m.Name),
                                    new JProperty("Path",m.Path)
                                ))))
                        )))));

            ((JArray) deviceList["Devices"]).Add(JsonRepository.CreateJsonObject(de, d => new
            {
                d.Name,
                d.IpAddress,
                d.Port,
                MediaList = d.MediaList.Select(
                    m => new
                    {
                        m.Name,
                        m.Path
                    })
            }));
            //((JArray) deviceList["Devices"]).Add(new JObject(
            //    new JProperty("Name",de.Name),
            //    new JProperty("IPAddress",de.IpAddress),
            //    new JProperty("Port",de.Port),
            //    new JProperty("MediaList",de.MediaList.Select(
            //        m => new JObject(
            //            new JProperty("Name",m.Name),
            //            new JProperty("Path",m.Path))))));

            Console.WriteLine(deviceList.ToString());

            string json = JsonConvert.SerializeObject(devices.Select(d => new
            {
                MediaList = d.MediaList.Select(m => new
                {
                    m.Name
                })
            }),Formatting.Indented);
            Console.WriteLine(json);

            //JObject jObject = new JObject("Test", "Test");

            //Console.WriteLine(jObject.ToString());


            Console.Read();
        }
    }
}
