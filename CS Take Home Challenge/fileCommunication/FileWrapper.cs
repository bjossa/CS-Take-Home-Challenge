using System.IO;

namespace CS_Take_Home_Challenge.fileCommunication
{
    public class FileWrapper :
        IFileWrapper
    {
        #region constructor

        public FileWrapper()
        {

        }

        #endregion

        #region implementation of IFileWrapper

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string[] ReadAllLinesFromFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        #endregion
    }
}
