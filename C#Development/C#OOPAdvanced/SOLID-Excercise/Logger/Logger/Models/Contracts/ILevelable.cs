namespace Logger.Models.Contracts
{
    using Enums;

    public interface ILevelable
    {
        ErrorLevel ErrorLevel { get; }
    }
}