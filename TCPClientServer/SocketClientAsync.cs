using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientServer
{
    public class SocketClientAsync
    {
        // IP Serwera
        IPAddress mServerIpAddress;
        // Port Serwera
        int mServerPort;
        // Zmienna klient
        TcpClient mClient;

        // Wyjątki
        // Zgłoszenie zdarzenia Otrzymano tekst
        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        // Zgłoszenie zdarzenia Wysłano tekst
        public EventHandler<TextSendEventArgs> RaiseTextSendEvent;
        // Zgłoszenie zdarzenia Podłączono do serwera
        public EventHandler<ServerConnectedEventArgs> RaiseServerConnectedEvent;
        // Zgłoszenie zdarzenia Odłączono od serwera
        public EventHandler<ServerDisconnectedEventArgs> RaiseServerDisconnectedEvent;


        // Obsługa zdarzenia Otrzymano tekst
        protected virtual void OnRaiseTextReceivedEvent(TextReceivedEventArgs e)
        {
            // Wywołanie zdarzenia w starym formacie?
            //EventHandler<TextReceivedEventArgs> handler = RaiseTextReceivedEvent;
            //if (handler != null)
            //{
            //    handler(this, e);
            //}

            // Wywołanie zdarzenia
            RaiseTextReceivedEvent?.Invoke(this, e);
        }

        // Obsługa zdarzenia Wysłano tekst
        protected virtual void OnRaiseTextSendEvent(TextSendEventArgs e)
        {
            // Wywołanie zdarzenia
            RaiseTextSendEvent?.Invoke(this, e);
        }

        // Obsługa zdarzenia Podłączono do serwera
        protected virtual void OnRaiseServerConnectedEvent(ServerConnectedEventArgs e)
        {
            // Wywołanie zdarzenia
            RaiseServerConnectedEvent?.Invoke(this, e);
        }

        // Obsługa zdarzenia Odłączono do serwera
        protected virtual void OnRaiseServerDisconnectedEvent(ServerDisconnectedEventArgs e)
        {
            // Wywołanie zdarzenia
            RaiseServerDisconnectedEvent?.Invoke(this, e);
        }

    }
}
