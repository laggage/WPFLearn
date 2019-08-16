namespace Demo.Share.Models
{
    using System;
    using System.Collections.Generic;

    public class Book:IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public uint Price { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
