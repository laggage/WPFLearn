using System.Collections.Generic;
using System.ComponentModel;

namespace Demo.NewtonsoftJson
{
    public class Device
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public bool IsConnected { get; set; } = false;
        public DeviceState State => IsConnected ? DeviceState.OnLine : DeviceState.OffLine;
        public IEnumerable<Media> MediaList { get; }

        private Device()
        {
            Port = 1000;
        }

        public Device(string name,string ip,IEnumerable<Media> mediaList):this()
        {
            Name = name;
            IpAddress = ip;
            MediaList = mediaList;
        }

    }

    public enum DeviceState
    {
        [Description("在线")]
        OnLine,
        [Description("离线")]
        OffLine
    }
}
