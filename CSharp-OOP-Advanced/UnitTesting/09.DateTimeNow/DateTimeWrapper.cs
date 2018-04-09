using System;
using System.Collections.Generic;
using System.Text;

namespace _09.DateTimeNow
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTimeWrapper(DateTime currentDateTime)
        {
            this.CurrentDateTime = currentDateTime;
        }

        public DateTime CurrentDateTime { get; }

        public DateTime Now { get { return DateTime.Now; } }

        public void AddDays(double value)
        {
            this.CurrentDateTime.AddDays(value);
        }
    }
}
