using System;
using System.Windows;

namespace Demo.DIYControl.ThemeManager
{
    public class Accent
    {
        public ResourceDictionary Resources { get; set; }
        public string Name { get; set; }

        public Accent()
        {

        }

        public Accent(string name,ResourceDictionary resources)
        {
            Name = name;
            Resources = resources;
        }

        public Accent(string name,Uri resourcePath)
        {
            Name = name;
            Resources = new ResourceDictionary()
            {
                Source = resourcePath
            };
        }
    }
}
