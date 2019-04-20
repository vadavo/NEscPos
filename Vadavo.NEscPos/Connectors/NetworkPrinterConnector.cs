using System;
using System.Net;
using System.Net.Sockets;

namespace Vadavo.NEscPos.Connectors
{
    public class NetworkPrinterConnector : IPrinterConnector
    {
        private readonly IPEndPoint _endPoint;
        private Socket _socket;

        public NetworkPrinterConnector(IPEndPoint endPoint)
        {
            _endPoint = endPoint;
            _openSocket();
        }

        public NetworkPrinterConnector(IPAddress ipAddress, int port)
        {
            _endPoint = new IPEndPoint(ipAddress, port);
            _openSocket();
        }

        public NetworkPrinterConnector(string ipAddress, int port)
        {
            _endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            _openSocket();
        }

        private void _openSocket()
        {
            _socket = new Socket(_endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(_endPoint);
        }

        public void Dispose()
        {
            _socket?.Dispose();
        }

        public byte[] Read()
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] data)
        {
            _socket.Send(data);
        }
    }
}
