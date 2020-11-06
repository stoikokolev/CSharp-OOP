using System;
using System.Globalization;
using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Errors;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        public IError ProduceError(string dateStr, string message, string levelStr)
        {
            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateStr, GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid dateStr format!", e);
            }

            var hasParsed = Enum.TryParse<Level>(levelStr, true, out var level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            var error = new Error(dateTime, message, level);

            return error;
        }
    }
}
