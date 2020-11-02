using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Contacts;

namespace BorderControl.Models
{
    public class Citizen:IHuman,IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.BirthDate = birthdate;
        }

        public string ID { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string BirthDate { get; private set; }
    }
}
