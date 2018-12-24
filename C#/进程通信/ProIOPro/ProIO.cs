using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProIOPro
{
    public delegate void subReceive(string sValue);

    public enum TypeWayProIP
    {
        Message,
        Pip,
        Socket,
        VirMem
    }
    public class ProIO
    {
        TypeWayProIP _way = 0;
        bool _bIndex = true;

        public ProIO(int iWay,bool index, subReceive receiveFun)
        {
            _way = (TypeWayProIP)iWay;
            _bIndex = index;

            if (_way == TypeWayProIP.Message)
            {
                _Message = new SubProIOMessage();
            }
            else if (_way == TypeWayProIP.Pip)
            {
                _Pip = new SubProIOPip();
            }
            else if (_way == TypeWayProIP.Socket)
            {
                _Socket = new SubProIOSocket(index, receiveFun);
            }
            else if (_way == TypeWayProIP.VirMem)
            {
                _VirMem = new SubProIOVirMem();
            }
        }

        public ProIO(TypeWayProIP way, bool index, subReceive receiveFun)
        {
            _way = way;
            _bIndex = index;

            if (_way == TypeWayProIP.Message)
            {
                _Message = new SubProIOMessage();
            }
            else if (_way == TypeWayProIP.Pip)
            {
                _Pip = new SubProIOPip();
            }
            else if (_way == TypeWayProIP.Socket)
            {
                _Socket = new SubProIOSocket(index, receiveFun);
                Receive(receiveFun);
            }
            else if (_way == TypeWayProIP.VirMem)
            {
                _VirMem = new SubProIOVirMem();
            }

        }

        SubProIOMessage _Message = null;
        SubProIOPip     _Pip = null;
        SubProIOSocket  _Socket = null;
        SubProIOVirMem _VirMem = null;

        public void Init()
        {
            
        }

        public void Send(string value)
        {
            if (_way == TypeWayProIP.Message)
            {
                //_Message;
            }
            else if (_way == TypeWayProIP.Pip)
            {
                //_Pip;
            }
            else if (_way == TypeWayProIP.Socket)
            {
                _Socket.Send(value);
            }
            else if (_way == TypeWayProIP.VirMem)
            {
                //_VirMem;
            }

        }

        private  void Receive(subReceive parReceive)
        {
            if (_way == TypeWayProIP.Message)
            {
                //_Message;
            }
            else if (_way == TypeWayProIP.Pip)
            {
                //_Pip;
            }
            else if (_way == TypeWayProIP.Socket)
            {
                string value = "";


                _Socket.Receive(ref value);
                parReceive(value);
            }
            else if (_way == TypeWayProIP.VirMem)
            {
                //_VirMem;
            }

           
        }

        public void Release()
        {
            if (_Socket != null)
            {
                _Socket.Release();
            }

        }



        // 网络通信

        // 命名管道

        // 通过消息

        // 虚拟内存

    }
}
