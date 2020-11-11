using System;
using System.Linq;

namespace TestDemos
{
    public class Calculator
    {
        public int Sum(params int[] numbers) => numbers.Sum();

        public int Product(params int[] numbers) =>
             numbers.Aggregate(1, (current, t) => current * t);
    }
}

