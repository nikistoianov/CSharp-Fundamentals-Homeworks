using System;
using System.Collections.Generic;
using System.Text;

namespace _09.DateTimeNow
{
    public interface IDateTimeWrapper
    {
        DateTime CurrentDateTime { get; }

        DateTime Now { get; }

        void AddDays(double value);
    }
}
