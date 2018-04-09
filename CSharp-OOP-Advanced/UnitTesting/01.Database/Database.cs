using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Database
{
    public class Database
    {
        private const int DEFAULT_CAPACITY = 16;
        private int[] elements;
        private int currentIndex;

        public Database()
        {
            elements = new int[DEFAULT_CAPACITY];
            this.currentIndex = -1;
        }

        public Database(params int[] elements) : this()
        {
            if (elements.Length > DEFAULT_CAPACITY)
                throw new InvalidOperationException($"Lenght must be maximum {DEFAULT_CAPACITY}!");

            for (int i = 0; i < elements.Length; i++)
            {
                currentIndex++;
                this.elements[i] = elements[i];
            }
        }

        public void Add(int element)
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

            this.elements[currentIndex] = 0;
            currentIndex--;
        }

        public int[] Fetch()
        {
            return this.elements.Take(this.currentIndex + 1).ToArray();
        }
    }
}
