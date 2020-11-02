using System;
using MilitaryElite.Contracts;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text) => Console.Write(text);

        public void WriteLine(ISoldier text) => Console.WriteLine(text);
    }
}
