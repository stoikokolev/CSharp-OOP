using System;
using BorderControl.Contacts;

namespace BorderControl.IO
{
    public class ConsoleReader : IReader
    {
        public string Read() => Console.ReadLine();
    }
}
