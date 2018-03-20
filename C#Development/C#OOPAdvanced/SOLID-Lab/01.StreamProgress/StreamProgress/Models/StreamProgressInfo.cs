namespace StreamProgress.Models
{
    public class StreamProgressInfo
    {
        public StreamProgressInfo(IStreamProgressInfo file) => this.File = file;

        public IStreamProgressInfo File { get; }

        public int CalculateCurrentPercent() => (this.File.BytesSent * 100) / this.File.Length;
    }
}