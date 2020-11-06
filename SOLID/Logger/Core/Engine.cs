using System;
using Logger.Core.Contracts;
using Logger.Factories;
using Logger.Models.Contracts;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
        : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == null) continue;
                var inputArgs = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

                var level = inputArgs[0];
                var dateTime = inputArgs[1];
                var message = inputArgs[2];

                try
                {
                    var error = this.errorFactory.ProduceError(dateTime, message, level);
                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}
