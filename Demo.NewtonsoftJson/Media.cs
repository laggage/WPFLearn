using System.IO;

namespace Demo.NewtonsoftJson
{
    public abstract class Media
    {
        public string Path { get; set; }

        public string Name => System.IO.Path.GetFileName(Path);

        //public long FileSize => new FileInfo(Path).Length;

        public override string ToString() => Name;
    }
}
