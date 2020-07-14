using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge.fileCommunication
{
    public class FileFacade: IFileFacade
    {
        #region Private Fields
        private string m_filePath;
        #endregion

        #region Constructors
        public FileFacade(string filePath = null)
        {
            m_filePath = filePath;
        }
        #endregion

        #region Properties
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion

        #region Specific Interface Implementation

        #region Implementation of <InterfaceName>

        #endregion

        #endregion
        public string[] ReadLinesFromFile()
        {
            if (m_filePath == null)
            {
                throw new FileCommunicationException ("filePath is null");
            }
            string[] unparsedPeople;
            try
            {
                unparsedPeople = File.ReadAllLines(m_filePath);
            }
            catch (FileNotFoundException)
            {
                throw new FileCommunicationException ("invalid file path provided");
            }
            return unparsedPeople;
        }
    }
}
