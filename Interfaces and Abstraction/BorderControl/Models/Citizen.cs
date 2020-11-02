using BorderControl.Contacts;

namespace BorderControl.Models
{
    public class Citizen:IHuman
    {
        private int food;

        public Citizen()
        {
            this.food = 0;
        }

        public Citizen(string name, int age, string id, string birthdate)
        :this()
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
        
        public int Food { get => this.food; }
        
        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
