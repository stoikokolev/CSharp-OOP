using MilitaryElite.Core;
using MilitaryElite.Core.Contracts;
using MilitaryElite.IO;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader,writer);

            engine.Run();
        }
    }
}
