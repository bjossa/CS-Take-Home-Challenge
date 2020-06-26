using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge
{
    public class Messanger
    {
        #region Private Fields
        private static Messanger _instance;
        #endregion

        #region Constructors
        public Messanger()
        {

        }
        #endregion

        #region Properties
        public static Messanger Default
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Messanger();
                }
                return _instance;
            }
        }
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        #endregion

        #region Public Methods
        public void Register<T> (object recipient, Action<T> action)
        {
            //Register(recipient, action, null);

        }

        public void Send<T> (T message)
        {
            //Send(message, null);
        }
        #endregion

        #region Private Methods
        #endregion

        #region Specific Interface Implementation

        #region Implementation of <InterfaceName>

        #endregion

        #endregion
    }
}
