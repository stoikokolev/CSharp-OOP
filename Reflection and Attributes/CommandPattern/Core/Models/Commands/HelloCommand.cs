using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args) => $"Hello, {args[0]}";
    }
}
