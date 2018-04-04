 namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            //TODO put your reflection code here
            var type = typeof(HarvestingFields);
            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {                
                var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                foreach (var field in fields)
                {
                    if (command == "all" || 
                        (command == "private" && field.IsPrivate) || 
                        (command == "protected" && field.IsFamily) || 
                        (command == "public" && field.IsPublic))
                    {
                        var modifier = field.Attributes.ToString().ToLower();
                        if (modifier == "family")
                            modifier = "protected";
                        Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
                    }
                    
                }
            }
        }
    }
}
