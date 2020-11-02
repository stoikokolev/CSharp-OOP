using BorderControl.Contacts;
using BorderControl.Core;
using BorderControl.IO;

namespace BorderControl
{
   public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader,writer);

            engine.Run();
        }
    }
}
