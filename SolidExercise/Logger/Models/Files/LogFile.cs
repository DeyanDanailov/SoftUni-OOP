

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.IOManagement;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private IOManager IOManager;
        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryAndFileExist();
        }
        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = String.Format(format, dateTime.ToString(GlobalConstants.DATE_FORMAT,
                CultureInfo.InvariantCulture),
                message, level.ToString()) + Environment.NewLine;

            return formattedMessage;
        }
        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);
            long size = text
                .Where(ch => Char.IsLetter(ch))
                .Sum(ch => ch);

            return size;
        }
    }
}
