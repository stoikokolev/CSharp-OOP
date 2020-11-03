using Vehicles.Core;
using Vehicles.Core.Contracts;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            var engine=new Engine();
            engine.Run();
        }
    }
}
