using System.Collections.ObjectModel;

namespace Demo.DataTrigger
{
    public class Places:ObservableCollection<Place>
    {
        public Places()
        {
            Add(new Place("南京", "江苏省"));
            Add(new Place("宁波", "浙江省"));
            Add(new Place("苏州", "江苏省"));
            Add(new Place("南通", "江苏省"));
            Add(new Place("深圳", "广州省"));
            Add(new Place("芜湖", "安徽省"));
            Add(new Place("东菀", "广东省"));
            Add(new Place("无锡", "江苏省"));
            Add(new Place("南昌", "江西省"));
        }
    }
}
