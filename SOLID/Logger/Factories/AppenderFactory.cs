using System;
using Logger.Models.Appenders;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Files;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory=new LayoutFactory();
        }

        public IAppender ProduceAppender(string appenderType, string layoutType, string levelStr)
        {
            var hasParsed = Enum.TryParse<Level>(levelStr, true, out var level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            var layout = this.layoutFactory.ProduceLayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender=new ConsoleAppender(layout,level);
            }
            else if (appenderType == "FileAppender")
            {
                var file = new LogFile("\\data\\","logs.txt");
                appender=new FileAppender(layout,level,file);
            }
            else
            {
                throw new ArgumentException("Invalid appender type!");
            }

            return appender;
        }
    }
}
