using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Contacts;

namespace BorderControl.Models
{
    public class Citizen:IHuman
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }

        public string ID { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }
}
