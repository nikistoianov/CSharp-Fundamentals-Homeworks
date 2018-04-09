using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.ExtendedDatabase
{
    public class Database<T>
    {
        private const int DEFAULT_CAPACITY = 16;
        protected T[] elements;
        protected int currentIndex;
        //private 

        public Database()
        {
            elements = new T[DEFAULT_CAPACITY];
            this.currentIndex = -1;
        }

        public Database(params T[] elements) : this()
        {
            if (elements.Length > DEFAULT_CAPACITY)
                throw new InvalidOperationException($"Lenght must be maximum {DEFAULT_CAPACITY}!");

            for (int i = 0; i < elements.Length; i++)
            {
                currentIndex++;
                this.elements[i] = elements[i];
            }
        }

        public virtual void Add(T element)
        {
            if (currentIndex >= DEFAULT_CAPACITY - 1)
                throw new InvalidOperationException("Database is full!");

            currentIndex++;
            this.elements[currentIndex] = element;
        }

        public void Remove()
        {
            if (currentIndex == -1)
                throw new InvalidOperationException("Database is empty!");

            //this.elements[currentIndex] = default;
            currentIndex--;
        }

        public T[] Fetch()
        {
            return this.elements.Take(this.currentIndex + 1).ToArray();
        }
    }
}
