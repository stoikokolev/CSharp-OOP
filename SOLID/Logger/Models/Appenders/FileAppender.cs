using Logger.Models.Contracts;
using Logger.Models.Enumerations;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public long MessagesAppend { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            var formattedMessage = this.File.Write(this.Layout, error);

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);

            this.MessagesAppend++;
        }

        public override string ToString() => $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessagesAppend}, File size: {this.File.Size}";
    }
}
