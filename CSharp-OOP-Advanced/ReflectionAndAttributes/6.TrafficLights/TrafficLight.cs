using System;
using System.Collections.Generic;
using System.Text;

namespace _6.TrafficLights
{
    public class TrafficLight
    {
        private List<string> lights;

        public List<string> Lights
        {
            get { return lights; }
            private set { lights = value; }
        }

        public TrafficLight(string[] lights)
        {
            this.Lights = new List<string>(lights);
        }

        public void ChangeLights()
        {
            for (int i = 0; i < this.Lights.Count; i++)
            {
                switch (this.Lights[i])
                {
                    case "Green":
                        this.Lights[i] = "Yellow";
                        break;
                    case "Red":
                        this.Lights[i] = "Green";
                        break;
                    case "Yellow":
                        this.Lights[i] = "Red";
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
