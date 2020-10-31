using System;
using Telephony.Contracts;

namespace Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
