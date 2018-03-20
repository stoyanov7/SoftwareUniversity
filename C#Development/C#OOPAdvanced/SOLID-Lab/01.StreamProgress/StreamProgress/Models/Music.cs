namespace StreamProgress.Models
{
    public class Music : IStreamProgressInfo
    {
        public Music(string artist, string album, int length, int bytesSent)
        {
            this.Artist = artist;
            this.Album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Artist { get; set; }

        public string Album { get; set; }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
