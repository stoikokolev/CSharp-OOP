using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Contacts;

namespace BorderControl.Models
{
    public class Rabel : IRabel
    {
        private int food;

        public Rabel()
        {
            this.food = 0;
        }

        public Rabel(string name, int age, string group)
            : this()
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; }

        public int Age { get; }

        public string Group { get; }

        public int Food => this.food;

        public void BuyFood()
        {
            this.food += 5;
        }

    }
}
