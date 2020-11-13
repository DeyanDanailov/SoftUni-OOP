
using System;
using System.Globalization;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Errors;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string DATE_FORMAT = "M/dd/yyyy H:mm:ss tt";
        public IError ProduceError(string dateStr, string message, string levelStr)
        {
            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(dateStr, DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid date format!", e);
            }
            Level level;
            bool hasParsed = Enum.TryParse<Level>(levelStr, true, out level);
            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            IError error = new Error(dateTime, message, level);

            return error;
        }
    }
}
