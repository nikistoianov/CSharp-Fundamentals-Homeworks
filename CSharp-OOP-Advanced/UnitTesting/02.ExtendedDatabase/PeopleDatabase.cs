using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _02.ExtendedDatabase
{
    public class PeopleDatabase : Database<Person>
    {
        public PeopleDatabase() : base()
        {
        }

        public PeopleDatabase(params Person[] people) : this()
        {
            foreach (var person in people)
            {
                //this.currentIndex++;
                this.Add(person);
            }
        }

        public override void Add(Person person)
        {
            var foundPerson = this.elements.FirstOrDefault(x => x?.UserName == person.UserName || x?.Id == person.Id);
            if (foundPerson != null)
                throw new InvalidOperationException("Existing user!");
            base.Add(person);
        }

        public Person FindById(long id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("Id can not be negative!");
            var foundPerson = this.elements.FirstOrDefault(x => x?.Id == id);
            if (foundPerson == null)
                throw new InvalidOperationException($"No user with id: {id}!");
            
            return foundPerson;
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
                throw new ArgumentOutOfRangeException("Username can not be null!");
            var foundPerson = this.elements.FirstOrDefault(x => x?.UserName == username);
            if (foundPerson == null)
                throw new InvalidOperationException($"No user with username: {username}!");
            
            return foundPerson;
        }
    }
}
