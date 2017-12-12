using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Logging
{
    public interface ILogger
    {
        void Debug(DateTime time, string message, string additionalInfo = null);
        void Info(DateTime time, string message, string additionalInfo = null);
        void Warn(DateTime time, string message, string additionalInfo = null);
        void Error(DateTime time, string message, string additionalInfo = null);
        void Fatal(DateTime time, string message, string additionalInfo = null);
    }
}
