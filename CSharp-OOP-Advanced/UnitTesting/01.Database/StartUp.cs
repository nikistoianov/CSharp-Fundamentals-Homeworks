using System;

namespace _01.Database
{
    class StartUp
    {
        static void Main()
        {
            var database = new Database();
            database.Add(1);
            database.Add(2);
            database.Add(5);
            database.Remove();
            database.Add(6);
            database.Remove();
            database.Remove();
            database.Remove();
            var result = database.Fetch();
        }
    }
}
