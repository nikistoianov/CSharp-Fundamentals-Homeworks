using System;
using System.Collections.Generic;
using System.Text;

namespace _6.TrafficLights
{
    using _6.TrafficLights;
    class Program
    {        
        static void Main()
        {
            var trafficLights = new List<TrafficLight>();

            var lights = Console.ReadLine().Split();
            var numberOfLightChanges = int.Parse(Console.ReadLine());
            
            var trafficLight = new TrafficLight(lights);

            for (int i = 0; i < numberOfLightChanges; i++)
            {
                var result = new StringBuilder();
                trafficLight.ChangeLights();

                foreach (var light in trafficLight.Lights)
                {
                    result.Append(light + " ");
                }

                Console.WriteLine(result.ToString().TrimEnd());
            }
        }
    }
}
