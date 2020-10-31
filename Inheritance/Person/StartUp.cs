using System;

namespace Person
{
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person child = new Person(name, age); // person = new person - 100/100; child = new child = 66/100 
            Console.WriteLine(child);
        }
    }
}