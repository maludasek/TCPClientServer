using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientServer
{
    // Argumenty zdarzenia OnRaiseServerStartEvent
    public class ServerStartEventArgs : EventArgs
    {
        public string ServerIP { get; set; }
        public int Port { get; set; }
        public ServerStartEventArgs(string serverIP, int port)
        {
            ServerIP = serverIP;
            Port = port;
        }
    }

    // Argumenty zdarzenia OnRaiseServerStopEvent
    public class ServerStopEventArgs : EventArgs
    {
        public string ServerIP { get; set; }
        public int Port { get; set; }
        public ServerStopEventArgs(string serverIP, int port)
        {
            ServerIP = serverIP;
            Port = port;
        }
    }

    // Argumenty zdarzenia OnRaiseServerConnectedEvent
    public class ServerConnectedEventArgs : EventArgs
    {
        public string ServerIp { get; set; }
        public string ServerPort { get; set; }
        public ServerConnectedEventArgs(string serverIp, string serverPort)
        {
            ServerIp = serverIp;
            ServerPort = serverPort;
        }
    }

    // Argumenty zdarzenia OnRaiseServerDisconnectedEvent
    public class ServerDisconnectedEventArgs : EventArgs
    {
        public string ServerIp { get; set; }
        public string ServerPort { get; set; }
        public ServerDisconnectedEventArgs(string serverIp, string serverPort)
        {
            ServerIp = serverIp;
            ServerPort = serverPort;
        }
    }

    // Argumenty zdarzenia OnRaiseClientDisconnectedEvent
    public class ClientDisconnectedEventArgs : EventArgs
    {
        public string OldClient { get; set; }
        public int ClientCount { get; set; }
        public ClientDisconnectedEventArgs(string oldClient, int clientCount)
        {
            OldClient = oldClient;
            ClientCount = clientCount;
        }
    }

    // Argumenty zdarzenia OnRaiseClientConnectedEvent
    public class ClientConnectedEventArgs : EventArgs
    {
        public string NewClient { get; set; }
        public int ClientCount { get; set; }
        public ClientConnectedEventArgs(string newClient, int clientCount)
        {
            NewClient = newClient;
            ClientCount = clientCount;
        }
    }

    // Argumenty zdarzenia OnRaiseTextReceivedEvent
    public class TextReceivedEventArgs : EventArgs
    {
        public string ClientSender { get; set; }
        public string TextReceived { get; set; }
        public TextReceivedEventArgs(string clientSender, string textReceived)
        {
            ClientSender = clientSender;
            TextReceived = textReceived;
        }
    }

    // Argumenty zdarzenia OnRaiseTextSendToAllEvent
    public class TextSendToAllEventArgs : EventArgs
    {
        public string TextSend { get; set; }
        public TextSendToAllEventArgs(string textSend)
        {
            TextSend = textSend;
        }
    }

}
