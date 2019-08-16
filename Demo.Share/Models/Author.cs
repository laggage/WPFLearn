namespace Demo.Share.Models
{
    public class Author:IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
    }
}
