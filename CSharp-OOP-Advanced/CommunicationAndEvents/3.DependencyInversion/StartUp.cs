namespace _3.DependencyInversion
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var calculator = new PrimitiveCalculator();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command.StartsWith("mode"))
                {
                    var operand = command.Split()[1];
                    calculator.ChangeStrategy(operand[0]);
                }
                else
                {
                    var args = command.Split().Select(int.Parse).ToArray();
                    var result = calculator.PerformCalculation(args[0], args[1]);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
