using MilitaryElite.Contracts;

namespace MilitaryElite.IO.Contracts
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(ISoldier text);
    }
}
