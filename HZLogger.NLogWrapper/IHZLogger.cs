using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZLogger.NLogWrapper
{
    public interface IHZLogger
    {
        void Trace(string msg);

        void Debug(string msg);

        void Warn(string msg);

        void Info(string msg);

        void Error(string msg);

        void Error(Exception exception);

        void Fatal(string msg);

    }
}
