using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service_Booking_System.Utility
{
    public interface ILogger
    {
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
    }
}