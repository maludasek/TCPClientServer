using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
        private bool IncomingFile { get; set; }
        private string PlikContent;
        private byte[] bytePlik;
        private char[] charPlik;

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
            // Wywołanie zdarzenia w starym formacie?
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

            // Próba uruchomienia Serwera
            try
            {
                // Tworzy listenera z ustawieniami IP i portu
                mIP = ipAddr;
                mPort = port;
                mTcpListener = new TcpListener(mIP, mPort);
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
                    TakeCareOfTcpClient(newClient);
                }
            }
            catch (Exception ex)
            {
                // Wyślij błąd do debuggera - dorobić
                Debug.WriteLine(String.Format("Exception message: {0}", ex.Message.ToString()));
            }
        }

        // Obsłuż klienta newClient
        private async void TakeCareOfTcpClient(TcpClient paramClient)
        {
            // Deklaracja strumienia sieciowego
            NetworkStream stream = null;

            // Deklaracja strumienia pliku
            Stream plikStream = null;

            // Deklaracja czytnika strumieni
            StreamReader reader = null;

            try
            {
                // Podłączenie strumienia z klienta
                stream = paramClient.GetStream();
                // Czytanie strumienia klienta
                reader = new StreamReader(stream);
                // Deklaracja bufora strumienia
                char[] buff = new char[512];
                // Czytanie danych gdy Serwer chodzi 
                while (KeepRunning)
                {
                    // Czytaj asynchronicznie strumień od klienta - nRet ilość przeczytanych danych
                    int nRet = await reader.ReadAsync(buff, 0, buff.Length);
                    //int recv = await stream.ReadAsync(buffByte, 0, buffByte.Length);
                    // Jeżeli ilość danych jest równa 0
                    if (nRet == 0)
                    {
                        // Usuń klienta z listy i obsłuż odłączenie się klienta
                        RemoveClient(paramClient);
                        // przerwij pętle czytania danych od klienta
                        break;
                    }
                    // Konwersja bufora na string
                    string receivedText = new string(buff);

                    if (receivedText.StartsWith("<BeginPlikName>"))
                    {
                        IncomingFile = true;
                        PlikContent = "";
                        bytePlik = new byte[0];
                        charPlik = new char[0];

                        OnRaiseTextReceivedEvent(new TextReceivedEventArgs(paramClient.Client.RemoteEndPoint.ToString(), "Zaczynam zapisywanie pliku od klienta: " + paramClient.Client.RemoteEndPoint.ToString()));
                    }
                    if (IncomingFile)
                    {
                        PlikContent += receivedText;

                        char[] tmpChar = new char[charPlik.Length + buff.Length];
                        charPlik.CopyTo(tmpChar, 0);
                        buff.CopyTo(tmpChar, charPlik.Length);
                        charPlik = new char[tmpChar.Length];
                        tmpChar.CopyTo(charPlik, 0);

                        byte[] tmpBytes = Encoding.ASCII.GetBytes(buff);
                        int i = bytePlik.Length;
                        Array.Resize<byte>(ref bytePlik, i + tmpBytes.Length);
                        tmpBytes.CopyTo(bytePlik, i);
                    }
                    if (receivedText.Contains("</End>"))
                    {
                        PlikContent += receivedText;
                        IncomingFile = false;

                        string test = charPlik.ToString();

                        int startSciezkaPos = PlikContent.IndexOf("<BeginPlikName>") + 15;
                        int endSciezkaPos = PlikContent.IndexOf("</BeginPlikName>");
                        string sciezka = Environment.CurrentDirectory;
                        sciezka += "\\" + PlikContent.Substring(startSciezkaPos, (PlikContent.Length - startSciezkaPos) - (PlikContent.Length - endSciezkaPos));

                        int startPos = PlikContent.IndexOf("<Begin>") + 7;
                        int endPos = PlikContent.IndexOf("</End>");
                        string plik = PlikContent.Substring(startPos, (PlikContent.Length - startPos) - (PlikContent.Length - endPos));



                        if (File.Exists(sciezka))
                        {
                            File.Delete(sciezka);
                        }

                        using (FileStream zapisz = new FileStream(sciezka, FileMode.Create))
                        {
                            zapisz.Write(bytePlik, startPos, (bytePlik.Length - startPos) - (bytePlik.Length - endPos));

                            //StreamWriter swPlik = new StreamWriter(zapisz);
                            //swPlik.Write(charPlik, startPos, (charPlik.Length - startPos) - (charPlik.Length - endPos));
                            //swPlik.Close();
                        }

                        //File.WriteAllText(sciezka, plik);

                        OnRaiseTextReceivedEvent(new TextReceivedEventArgs(paramClient.Client.RemoteEndPoint.ToString(), "Zakończono zapisywanie pliku od klienta: " + paramClient.Client.RemoteEndPoint.ToString()));
                        Debug.WriteLine(plik);
                    }

                    if (!IncomingFile && !receivedText.Contains("</End>") && !receivedText.StartsWith("<BeginPlikName>"))
                    {
                        // Przesyła dane z bufora do debugera
                        // Debug.WriteLine(String.Format("*** Received: {0}", receivedText));

                        // Obsługuje zdarzenie odczytania danych od klienta
                        OnRaiseTextReceivedEvent(new TextReceivedEventArgs(paramClient.Client.RemoteEndPoint.ToString(), receivedText));

                    }

                    // Czyszczenie bufora
                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception ex)
            {
                // Usuń klienta z listy i obsłuż odłączenie się klienta
                RemoveClient(paramClient);

                // Wyślij komunikat do debugera z błędem
                Debug.WriteLine(String.Format("Exception message: {0}", ex.Message.ToString()));
            }
        }


        // Usuwa klienta z listy i obsługuje zdarzenie odłączenia się klienta od serwera
        private void RemoveClient(TcpClient paramClient)
        {
            // Jeżeli na liście klientów serwera znajduje się dany klient
            if (mClients.Contains(paramClient))
            {
                // Usuń klienta z listy
                mClients.Remove(paramClient);
                // Obsłuż odłączenie się klienta
                OnRaiseClientDisconnectedEvent(new ClientDisconnectedEventArgs(paramClient.Client.RemoteEndPoint.ToString(), mClients.Count));

                KeepRunning = false;

                // Wyślij komunikat do debugera
                // Debug.WriteLine(String.Format("Client: {0} disconnected, # of connected clients {1}", paramClient.Client.RemoteEndPoint, mClients.Count));
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

        // Wyślij z Serwera do wszystkich klientów z listy text message
        public async void SendToAll(string textMessage)
        {
            // Wróć jeżeli pusty message
            if (string.IsNullOrEmpty(textMessage))
            {
                return;
            }
            // Spróbuj wysłać textMessage do klientów
            try
            {
                // Konwertuj string na bajty
                byte[] buffMessage = Encoding.ASCII.GetBytes(textMessage);

                // Dla każdego klienta z listy
                foreach (var client in mClients)
                {
                    // Wyślij Stream (message) asynchronicznie do klienta
                    await client.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);

                    // Obsłuż zdarzenie wyślij message do wszystkich - robić dla każdego klienta czy tylko raz?
                    OnRaiseTextSendToAllEvent(new TextSendToAllEventArgs(textMessage));
                }
            }
            catch (Exception ex)
            {
                // Wyślij błąd do debuggera - dorobić
                Debug.WriteLine(String.Format("Exception message: {0}", ex.Message.ToString()));
            }
        }

    }
}
