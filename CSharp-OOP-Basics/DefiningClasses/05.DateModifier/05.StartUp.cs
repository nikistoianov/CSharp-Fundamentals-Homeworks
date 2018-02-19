using System;

class Program
{
    static void Main()
    {
        var modifier = new DateModifier(Console.ReadLine(), Console.ReadLine());
        Console.WriteLine(modifier.GetDaysSpan());
    }
}
