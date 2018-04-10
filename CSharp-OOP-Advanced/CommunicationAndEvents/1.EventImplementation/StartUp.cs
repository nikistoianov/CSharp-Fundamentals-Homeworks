using System;

namespace _1.EventImplementation
{
    class StartUp
    {
        static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                dispatcher.Name = command;
            }
            
        }
    }
}
