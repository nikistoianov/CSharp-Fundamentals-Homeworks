namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            //TODO put your reflection code here
            //var bb = new BlackBoxInteger(1,);
            var blackBox = Activator.CreateInstance(typeof(BlackBoxInteger), true);
            var type = blackBox.GetType();
            var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)[0];
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var args = command.Split('_');
                var method = type.GetMethod(args[0], BindingFlags.NonPublic | BindingFlags.Instance);
                object[] param = { int.Parse(args[1]) };
                method.Invoke(blackBox, param);
                var result = field.GetValue(blackBox);
                Console.WriteLine(result);
            }
        }
    }
}
