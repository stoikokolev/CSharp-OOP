using System.Linq;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number) => !number.All(char.IsDigit) ? throw new InvalidNumberException() : $"Dialing... {number}";
    }
}
