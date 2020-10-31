using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private const int PERSON_MIN_AGE = 0;
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public virtual int Age
        {
            get => this.age;
            protected set
            {
                if (value >= PERSON_MIN_AGE)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
