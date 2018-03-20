namespace StreamProgress.Models
{
    public interface IStreamProgressInfo
    {
        int Length { get; }

        int BytesSent { get; }
    }
}