using System;
using System.Linq;
using Telephony.Contracts;
using Telephony.Exceptions;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;

        private Engine()
        {
            this.smartphone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var phoneNumbers = reader.ReadLine().Split().ToArray();
            var sites = reader.ReadLine().Split().ToArray();

            CallNumbers(phoneNumbers);

            BrowseSites(sites);
        }

        private void BrowseSites(string[] sites)
        {
            foreach (var url in sites)
            {
                try
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidUrlException iue)
                {
                    writer.WriteLine(iue.Message);
                }
            }
        }

        private void CallNumbers(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    switch (number.Length)
                    {
                        case 7:
                            writer.WriteLine(stationaryPhone.Call(number));
                            break;
                        case 10:
                            writer.WriteLine(smartphone.Call(number));
                            break;
                        default:
                            throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException ine)
                {
                    writer.WriteLine(ine.Message);
                }
            }
        }
    }
}
