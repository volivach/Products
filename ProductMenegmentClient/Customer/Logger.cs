using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMenegmentClient
{
    public class Logger : ILogger
    {
        private string _logEntry;

        public string LogEntry
        {
            get { return _logEntry; }
            set { _logEntry = value; }
        }
        public void Log(string logEntry)
        {
            _logEntry = logEntry;
        }
    }
}