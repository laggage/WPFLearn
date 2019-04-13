using System;

namespace Demo.Share.Model.Models
{
    public enum Sex
    {
        Man,
        Woman
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public DateTime RegisterTime { get; }
        public string ThumbnailUrl { get; set; }

        public User()
        {
            RegisterTime = DateTime.Now;
        }
        public User(string name, int age, Sex sex):this()
        {
            Name = name;
            Age = age;
            Sex = sex;
        }
    }
}
