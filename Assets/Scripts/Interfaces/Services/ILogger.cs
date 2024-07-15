public interface ILogger : IService
{
    void Log(string message, ELogLevel level = ELogLevel.Info);
}
