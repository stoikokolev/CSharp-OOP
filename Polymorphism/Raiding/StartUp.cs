using System;
using Raiding.Core;
using Raiding.IO;
using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
