using System;
namespace ProductMenegmentClient
{
    public interface ILogger
    {
        void Log(string logEntry);
        string LogEntry { get; }
    }
}