using System.IO;
using Logger.Models.Contracts;

namespace Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;

        private string folderName;
        private string fileName;

        private IOManager()
        {
            this.currentPath = this.GetCurrentDirectory();
        }

        public IOManager(string folderName, string fileName)
        : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath => this.currentPath + this.folderName;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.fileName;

        public string GetCurrentDirectory() => Directory.GetCurrentDirectory();

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }
    }
}
