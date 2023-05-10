namespace SentenceBuilderAPI.Actions.Interfaces
{
    public interface IExceptionsLogActions
    {
        Task LogException(string exceptionMessage, string methodName);
    }
}
