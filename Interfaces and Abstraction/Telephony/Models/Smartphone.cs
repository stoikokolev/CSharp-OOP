using System.Linq;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number) => !number.All(char.IsDigit) ? throw new InvalidNumberException() : $"Calling... {number}";

        public string Browse(string url) =>
            url.Any(char.IsDigit) ? throw new InvalidUrlException() : $"Browsing: {url}!";
    }
}
