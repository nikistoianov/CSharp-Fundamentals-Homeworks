using System;
using System.Collections.Generic;
using System.Text;

public class MoodFactory
{
    public string Mood { get; private set; }

    public MoodFactory(int happiness)
    {
        if (happiness < -5)
        {
            Mood = "Angry";
        }
        else if (happiness <= 0)
        {
            Mood = "Sad";
        }
        else if (happiness <= 15)
        {
            Mood = "Happy";
        }
        else
        {
            Mood = "JavaScript";
        }
    }
}
