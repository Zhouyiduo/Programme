using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessCommunicationUtility
{
    public delegate void subReceive(string sValue);

    public class SocketManager
    {
        bool _bIndex = true;

        public SocketManager(bool index, subReceive receiveFun)
        {
            _bIndex = index;
            _Socket = new SocketImp(index, receiveFun);
            Receive(receiveFun);
        }

        SocketImp _Socket = null;

        public void Send(string value)
        {
            _Socket.Send(value);
        }

        private void Receive(subReceive parReceive)
        {
            string value = "";
            _Socket.Receive(ref value);
            parReceive(value);
        }

        public void Release()
        {
            if (_Socket != null)
            {
                _Socket.Release();
            }
        }
    }
}
