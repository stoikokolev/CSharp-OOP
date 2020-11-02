﻿using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}