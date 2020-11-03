using System;
using Raiding.IO.Contracts;

namespace Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string Read() => Console.ReadLine();
    }
}
