using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace KSIS4FirstPlayer
{
    class Connection
    {
        public bool TryToConnect(Socket socket, IPEndPoint connectedSocketIpEndPoint)
        {
            try
            {
                socket.Connect(connectedSocketIpEndPoint);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WaitForConnection()
        {

        }

    }
}
