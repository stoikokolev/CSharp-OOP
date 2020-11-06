using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.IOManagement;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private IIOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryAndFileExist();
        }

        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        /// <summary>
        /// Returns formatted message in provided layout with provided error's data
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public string Write(ILayout layout, IError error)
        {
            var format = layout.Format;
            var dateTime = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            var formattedMessage = string.Format(format,
                dateTime.ToString(GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture),
                message,
                level.ToString())+Environment.NewLine;

            return formattedMessage;
        }

        private long GetFileSize()
        {
            var text = File.ReadAllText(this.Path);

            long size = text.Where(char.IsLetter).Sum(ch => ch);

            return size;
        }
    }
}
