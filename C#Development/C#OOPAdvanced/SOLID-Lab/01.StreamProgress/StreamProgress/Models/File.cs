namespace StreamProgress.Models
{
    public class File : IStreamProgressInfo
    {
        public File(string name, int length, int bytesSent)
        {
            this.Name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Name { get; }

        public int Length { get; }

        public int BytesSent { get; }
    }
}
