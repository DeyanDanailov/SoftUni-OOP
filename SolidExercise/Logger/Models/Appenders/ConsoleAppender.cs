

using System;
using System.Globalization;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }
        public ILayout Layout {get; private set;}

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = String.Format(format, dateTime.ToString("M/dd/yyyy H:mm:ss tt", CultureInfo.InvariantCulture), message, level.ToString());

            Console.WriteLine(formattedMessage);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
