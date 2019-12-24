using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.core.common
{
    public interface ILogger
    {
        void LogErrorMessage();
        void LogErrorMessage(string error);
        void LogErrorMessage(Exception ex);
    }
}
