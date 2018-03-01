using System;
using System.Collections.Generic;
using System.Text;


public class Food
{
    public int Happiness { get; private set; }
    public string Name { get; private set; }

    public Food(string foodInput)
    {
        Happiness += CalcHappiness(foodInput);
        Name = foodInput;
    }

    private int CalcHappiness(string foodInput)
    {
        switch (foodInput.ToLower())
        {
            case "cram":
                return 2;
            case "lembas":
                return 3;
            case "apple":
            case "melon":
                return 1;
            case "honeycake":
                return 5;
            case "mushrooms":
                return -10;
            default:
                return -1;
        }
    }
}