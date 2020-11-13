
using System.Collections.Generic;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;
        public Logger(ICollection <IAppender> appenders)
        {
            this.appenders = appenders;
        }
        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            throw new System.NotImplementedException();
        }
    }
}
