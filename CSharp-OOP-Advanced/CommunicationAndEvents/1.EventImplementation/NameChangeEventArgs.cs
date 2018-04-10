using System;
using System.Collections.Generic;
using System.Text;

namespace _1.EventImplementation
{
    public class NameChangeEventArgs : EventArgs
    {
        public string Name { get; private set; }

        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }
    }
}
