namespace Logger.Models.Contracts
{
    public interface IAppender : ILevelable
    {
        ILayout Layout { get; }
        
        void Append(IError error);
    }
}