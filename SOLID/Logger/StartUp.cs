using System;
using System.Collections.Generic;
using Logger.Core;
using Logger.Factories;
using Logger.Models.Contracts;

namespace Logger
{
    public class StartUp
    {
        static void Main()
        {
            var appenedrsCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            ParseAppendersInput(appenedrsCount, appenders);

            var logger = new Models.Logger(appenders);

            var engine = new Engine(logger);

            engine.Run();
        }

        private static void ParseAppendersInput(int appendersCount, ICollection<IAppender> appenders)
        {
            var appenderFactory = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                var appendersArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var appenderType = appendersArgs[0];
                var layoutType = appendersArgs[1];
                var level = "INFO";

                if (appendersArgs.Length == 3)
                {
                    level = appendersArgs[2];
                }

                try
                {
                    var appender = appenderFactory.ProduceAppender(appenderType, layoutType, level);

                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
