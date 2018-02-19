using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DateModifier
{
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }

    public DateModifier(string startDateLine, string endDateLine)
    {
        var splitLine = startDateLine.Split().Select(int.Parse).ToArray();
        startDate = new DateTime(splitLine[0], splitLine[1], splitLine[2]);

        splitLine = endDateLine.Split().Select(int.Parse).ToArray();
        endDate = new DateTime(splitLine[0], splitLine[1], splitLine[2]);
    }

    public int GetDaysSpan()
    {
        var span = endDate - startDate;
        return Math.Abs(span.Days);
    }
}
