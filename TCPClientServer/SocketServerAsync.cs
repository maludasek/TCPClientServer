using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        // Zgłoszenie zdarzenia Startu Serwera
        public EventHandler<ServerStopEventArgs> RaiseServerStopEvent;
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

        // Obsługa zdarzenia Stop Serwera
        protected virtual void OnRaiseServerStopEvent(ServerStopEventArgs e)
        {
            // Wywołanie zdarzenia
            RaiseServerStopEvent?.Invoke(this, e);
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

        // Włącza serwer metodą asynchroniczną
        public async void ServerStart(IPAddress ipAddr = null, int port = 23000)
        {
            // Gdy nie zostanie podany adres IP serwer nasłuchuje na wszystkich
            if (ipAddr == null)
            {
                ipAddr = IPAddress.Any;
            }
            // Jeżeli port jest spoza zakresu 1-65534 ustaw port nasłuchiwania na 23 000
            if (port < 0 || port > 65535)
            {
                port = 23000;
            }

            // Tworzy listenera z ustawieniami IP i portu
            mIP = ipAddr;
            mPort = port;
            mTcpListener = new TcpListener(mIP, mPort);

            // Próba uruchomienia Serwera
            try
            {
                // Startuje listenera
                mTcpListener.Start();
                // Obsłuż zdarzenie Startu Serwera
                OnRaiseServerStartEvent(new ServerStartEventArgs(mIP.ToString(), mPort));
                // Ustawia zmienną pamiętającą czy serwer działa na true
                KeepRunning = true;
                // Jeżeli Serwer jest uruchomiony obsłuż klientów
                while (KeepRunning)
                {
                    // Zaakceptuj nowego klienta asynchronicznie
                    var newClient = await mTcpListener.AcceptTcpClientAsync();
                    // Dodaj klienta do listy klientów
                    mClients.Add(newClient);

                    // Wyślij info do debugera o podłączonym kliencie
                    // Debug.WriteLine(String.Format("Client connected: {0}, # of clients connected: {1}", returnedByAccept.Client.RemoteEndPoint, mClients.Count));

                    // Obsłuż zdarzenie podłączenia klienta newClient
                    OnRaiseClientConnectedEvent(new ClientConnectedEventArgs(newClient.Client.RemoteEndPoint.ToString(), mClients.Count));

                    // Obsłuż klienta newClient - dorobić
                    // TakeCareOfTcpClient(newClient);
                }
            }
            catch (Exception ex)
            {
                // Wyślij błąd do debuggera - dorobić
                Debug.WriteLine(String.Format("Exception message: {0}", ex.Message.ToString()));
            }
        }

        // Zatrzymuje Serwer
        public void ServerStop()
        {
            // Ustawia zmienną pamiętającą czy serwer działa na false
            KeepRunning = false;
            //Próba zatrzymania Serwera
            try
            {
                // Zatrzymaj listenera jeżeli istnieje
                if (mTcpListener != null)
                {
                    mTcpListener.Stop();
                }
                // Odłącz klientów podłączonych do Serwera
                foreach (var client in mClients)
                {
                    // Jeżeli klient z listy jest podłączony
                    if (client.Connected)
                    {
                        // Odłącz klienta
                        client.Close();
                    }
                }
                // Opróżnij listę klientów
                mClients.Clear();
                // Obsłuż zdarzenie Zatrzymania Serwera
                OnRaiseServerStopEvent(new ServerStopEventArgs(mIP.ToString(), mPort));
            }
            catch (Exception ex)
            {
                // Wyślij błąd do debuggera - dorobić
                Debug.WriteLine(String.Format("Exception message: {0}", ex.Message.ToString()));
            }
        }
    }
}
