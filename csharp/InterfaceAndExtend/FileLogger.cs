using System.IO;

namespace InterfaceAndExtend
{
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            this._path = path;
        }

        public void LogError(string message)
        {
            Log(message, "Error");
        }

        public void LogInfo(string message)
        {
            Log(message, "Info");
        }

        private void Log(string message, string messageType)
        {
            // file recourse is not handled by CLR
            // that`s why we use this to handle this
            // if something goes wrong using will close that recourse
            // and also it closes FILE after it`s done and auto call dispose method

            using (var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine(messageType + " : " + message);
            }
        }
    }
}