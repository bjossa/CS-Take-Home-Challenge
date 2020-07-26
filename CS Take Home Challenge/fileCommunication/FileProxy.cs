namespace CS_Take_Home_Challenge.fileCommunication
{
    public class FileProxy :
        IFileProxy
    {
        #region Private Fields

        private string m_filePath;
        private IFileWrapper m_fileWrapper;

        #endregion

        #region Constructors

        public FileProxy(string filePath = null, IFileWrapper wrapper = null)
        {
            m_filePath = filePath;
            m_fileWrapper = wrapper ?? new FileWrapper();
        }

        #endregion

        #region implementation of IFileProxy

        public string[] ReadLinesFromFile()
        {
            string[] unparsedPeople;
            unparsedPeople = m_fileWrapper.ReadAllLinesFromFile(m_filePath);
            return unparsedPeople;
        }

        #endregion
    }
}
