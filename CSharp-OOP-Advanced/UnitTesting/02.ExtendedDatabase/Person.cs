using System;
using System.Collections.Generic;
using System.Text;

namespace _02.ExtendedDatabase
{
    public class Person
    {
        public long Id { get; private set; }
        public string UserName { get; private set; }

        public Person(long id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}
