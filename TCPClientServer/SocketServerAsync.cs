using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientServer
{
    public class SocketServerAsync
    {
        // IP Serwera
        IPAddress mIP;
        // Port Serwera
        int mPort;
        // Listener Serwera
        TcpListener mTcpListener;
        // Lista klientów podłączonych do serwera
        List<TcpClient> mClients;
        // Zmienna Czy Serwer pracuje
        public bool KeepRunning { get; set; }

        // Wyjątki
        // Zgłoszenie zdarzenia Startu Serwera
        public EventHandler<ServerStartEventArgs> RaiseServerStartEvent;
        // Zgłoszenie zdarzenia Odłączenia się klienta od Serwera
        public EventHandler<ClientDisconnectedEventArgs> RaiseClientDisconnectedEvent;
        // Zgłoszenie zdarzenia Podłączenia się klienta do Serwera
        public EventHandler<ClientConnectedEventArgs> RaiseClientConnectedEvent;
        // Zgłoszenie zdarzenia od Serwera Tekst odebrany 
        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        // Zgłoszenie zdarzenia od Serwera Tekst wysłany do wszystkich klientów
        public EventHandler<TextSendToAllEventArgs> RaiseTextSendToAllEvent;

        // Konstruktor
        public SocketServerAsync()
        {
            mClients = new List<TcpClient>();
        }

        // Obsługa zdarzenia Start Serwera
        protected virtual void OnRaiseServerStartEvent(ServerStartEventArgs e)
        {
            // Wywołanie zdarzenia w tarym formacie?
            //EventHandler<ServerStartEventArgs> handler = RaiseServerStartEvent;
            //if (handler != null)
            //{
            //    handler(this, e);
            //}

            // Wywołanie zdarzenia
            RaiseServerStartEvent?.Invoke(this, e);
        }

        // Obsługa zdarzenia Odłączenia się klienta od Serwera
        protected virtual void OnRaiseClientDisconnectedEvent(ClientDisconnectedEventArgs e)
        {
            // Wywołanie zdarzenia
            RaiseClientDisconnectedEvent?.Invoke(this, e);
        }

        // Obsługa zdarzenia Podłączenia się klienta do Serwera
        protected virtual void OnRaiseClientConnectedEvent(ClientConnectedEventArgs e)
        {
            // Wywołanie zdarzenia
            RaiseClientConnectedEvent?.Invoke(this, e);
        }

        // Obsługa zdarzenia od Serwera Tekst odebrany 
        protected virtual void OnRaiseTextReceivedEvent(TextReceivedEventArgs e)
        {
            // Wywołanie zdarzenia
            RaiseTextReceivedEvent?.Invoke(this, e);
        }

        // Obsługa zdarzenia od Serwera Tekst wysłany do wszystkich klientów
        protected virtual void OnRaiseTextSendToAllEvent(TextSendToAllEventArgs e)
        {
            // Wywołanie zdarzenia
            RaiseTextSendToAllEvent?.Invoke(this, e);
        }
    }
}
