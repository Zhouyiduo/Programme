using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Client.MVVM
{
    public class UIManager
    {
        #region Fields

        private static UIManager _instance = null;
        private static object _lock = new object();

        #endregion

        #region Properties

        public static Dispatcher UIDispatcher { get; set; }
        public static UIManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_lock)
                    {
                        if(_instance == null)
                        {
                            _instance = new UIManager();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Constructors

        private UIManager()
        { }

        #endregion
    }
}
