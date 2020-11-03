using WildFarm.Core;
using WildFarm.IO;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {
           var reader = new ConsoleReader();
           var writer = new ConsoleWriter();
           var engine = new Engine(reader,writer);
           
           engine.Run();
        }
    }
}
