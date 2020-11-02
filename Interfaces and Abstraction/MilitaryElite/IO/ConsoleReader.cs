using System;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite.IO
{
    public class ConsoleReader:IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
