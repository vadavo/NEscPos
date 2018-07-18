using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ESCPOS.NET.Connectors
{
    public class NetworkPrintConnector : IPrintConnector
    {
        private IPEndPoint _endPoint;
        private Socket _socket;

        public NetworkPrintConnector(IPEndPoint endPoint)
        {
            _endPoint = endPoint;
            _openSocket();
        }

        public NetworkPrintConnector(IPAddress ipAddress, int port)
        {
            _endPoint = new IPEndPoint(ipAddress, port);
            _openSocket();
        }

        public NetworkPrintConnector(string ipAddress, int port)
        {
            _endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            _openSocket();
        }

        private void _openSocket()
        {
            _socket = new Socket(_endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(_endPoint);
        }

        ~NetworkPrintConnector()
        {
            _socket.Close();
        }

        public void Dispose()
        {
            _socket.Dispose();
        }

        public byte[] Read()
        {
            byte[] buffer = null;
            _socket.Receive(buffer);

            return buffer;
        }

        public void Write(byte[] data)
        {
            _socket.Send(data);
        }
    }
}
