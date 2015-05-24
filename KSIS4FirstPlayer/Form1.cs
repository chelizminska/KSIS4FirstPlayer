using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace KSIS4FirstPlayer
{
    public partial class Form1 : Form
    {
        Game game;
        Connection connection;
        IPEndPoint thisIpEndPoint;
        IPEndPoint connectedIpEndPoint;
        Socket socket;
        Socket clientSocket;

        public Form1()
        {
            InitializeComponent();
            thisIpEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 1200);
            connectedIpEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 1201);
            socket = new Socket(thisIpEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(thisIpEndPoint);
            socket.Listen(1);
            connection = new Connection();
            game = new Game();
        }

           
        private void timer_Tick(object sender, EventArgs e)
        {

            Socket clientSock = socket.Accept();                

                string data = null;

           /*     byte[] bytes = new byte[1024];
                clientSock.Receive(bytes);
        clientsoc.shutdown
            clientsock.close


            Socket client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipEndPoint);
            Console.Write("Filename: ");  
            byte[] buf = {(byte)coordinatesY};
            int bytesSent = client.Send(buf);
            byte[] RecievedBlock = new byte[10];

            client.Receive(RecievedBlock);
            client.Shutdown(SocketShutdown.Both);
            client.Close();*/
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (connection.TryToConnect(socket, connectedIpEndPoint))
            {
                LabelMessages.Text = "abc";
                game.StartGame();
            }
            else
            {
                LabelMessages.Text = "false";
                connection.WaitForConnection();
                game.StartGame();
            }
        }

    }
}
