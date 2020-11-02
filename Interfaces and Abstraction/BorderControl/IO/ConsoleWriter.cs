using System;
using BorderControl.Contacts;

namespace BorderControl.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text) => Console.Write(text);

        public void WriteLine(int text) => Console.WriteLine(text);
    }
}
