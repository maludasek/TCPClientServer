using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientServer
{
    public class SocketClientAsync
    {
        // Zmienne globalne
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

        // Konstruktor
        public SocketClientAsync()
        {
            mServerIpAddress = null;
            mServerPort = -1;
            mClient = null;
        }

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

        // Ustawienie IP serwera
        private void SetServerIpAddress(string strHost)
        {
            // Próba przypsania IP do zmiennej IpAddress ipAddr
            if (!IPAddress.TryParse(strHost, out IPAddress ipAddr))
            {
                // Jeżeli się nie udało, sprawdź czy czasem klient nie podał host name
                try
                {
                    // Spróbuj zmienić host name na adres IP i przypsać do globalnej zmiennej mServerIpAddress
                    mServerIpAddress = Dns.GetHostAddresses(strHost).Where(addrf => addrf.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
                }
                catch (Exception)
                {
                    // Gdy zostanie zgłoszony wyjątek wyślij błąd o błędnym IP lub host name - obsłużyć
                    throw new ArgumentException("Host name or IP is invalid.");
                }
            }
            else
            {
                // IP jest włąściwe, więc przypisz je do zmiennej globalnej
                mServerIpAddress = ipAddr;
            }
        }

        // Ustawienie portu serwera
        public void SetServerPort(int portNumber)
        {
            // Sprawdź czy numer portu jest z zakresu od 1 do 65534
            if (portNumber <= 0 || portNumber > 65535)
            {
                // Jeżeli nie to wywal wyjątek o błędnym porcie - obsłużyć
                throw new ArgumentOutOfRangeException("Port number is invalid.");
            }
            // Przypisz port do zmiennej globalnej
            mServerPort = portNumber;
        }

        // Podłącz się do do serwera asynchronicznie
        public async Task ConnectToServer(string host, int port)
        {
            // ustaw IP serwera w zmiennej globalnej
            SetServerIpAddress(host);
            // ustaw port serwera w zmiennej globalnej
            SetServerPort(port);

            // Sprawdź czy klient już istnieje
            if (mClient == null)
            {
                // Jeżeli nie to stwórz nowego
                mClient = new TcpClient();
            }

            // Spróbuj się podłączyć do serwera i nasłuchiwać
            try
            {
                // podłącz klienta do serwera
                await mClient.ConnectAsync(mServerIpAddress, mServerPort);

                // Wyślij info do debugera, że podłączyłeś się do klienta
                //Debug.WriteLine("Connected to the server: {0}:{1}", mServerIpAddress.ToString(), mServerPort);

                // Obsłuż zdarzenie podłączenia się do klienta
                OnRaiseServerConnectedEvent(new ServerConnectedEventArgs(mServerIpAddress.ToString(), mServerPort.ToString()));

                // Nasłuchuj serwer
                await ReadDataAsync(mClient);
            }
            catch (Exception ex)
            {
                // Wyślij info do bebugera o błędzie - obsłużyć
                Debug.WriteLine("Exception message: {0}", ex.Message.ToString());
                // wywal aplikację 
                throw;
            }
        }

        // Czytaj dane od serwera asynchronicznie
        private async Task ReadDataAsync(TcpClient client)
        {
            // podłącz stream reader do network streamu klienta
            StreamReader clientStreamReader = new StreamReader(client.GetStream());
            // ustaw bufor na 64 znaki
            char[] buff = new char[64];

            // spróbuj czytac dane od serwera
            try
            {
                // sprawdź wielkość danych wysłanych od serwra
                int len = await clientStreamReader.ReadAsync(buff, 0, buff.Length);
                // słuchaj podczas gdy są dane
                while (len > 0)
                {
                    // zgłoś zdarzenie o przyjściu danych
                    OnRaiseTextReceivedEvent(new TextReceivedEventArgs(client.Client.RemoteEndPoint.ToString(),new string(buff)));
                    // sprawdź wielkość danych wysłanych od serwra
                    len = await clientStreamReader.ReadAsync(buff, 0, buff.Length);
                }
                // zamknij klienta
                mClient.Close();

                // drugi sposób słuchania serwera
                // deklaracja zmiennej 
                //int readByteCount = 0;
                // gdy prawda
                //while (true)
                //{
                //    // przypisz stream do zmiennej
                //    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);
                //    // jeżeli długość zmiennej streamu jest mniejsz lub równa 0
                //    if (readByteCount <= 0)
                //    {
                //        // Wyślij komunikat do debugera
                //        //Debug.WriteLine("Remote server has closed connection.");
                //        // zamknij klienta
                //        mClient.Close();
                //        // wyjdź z pętli
                //        break;
                //    }
                //    // wyślij stream do debugera
                //    //Debug.WriteLine(string.Format("Received bytes: {0} - Message: {1}",readByteCount, new string(buff)));
                //    // zgłość zdarzenie o otrzymaniu danych
                //    OnRaiseTextReceivedEvent(new TextReceivedEventArgs(
                //        client.Client.RemoteEndPoint.ToString(),
                //        new string(buff)));
                //    // wyczyść bufor
                //    Array.Clear(buff, 0, buff.Length);
                //}
            }
            // obsłuż wyjątek braku obiektu
            catch (ObjectDisposedException)
            {
                // zamknij stream reader
                clientStreamReader.Close();
            }
            // obsłuż inne wyjątki
            catch (Exception ex)
            {
                // wyślij błąd do debugera - obsłużyć
                Debug.WriteLine("Exception message: {0}", ex.Message.ToString());
                // Wysyp aplikację
                throw;
            }
        }

        // Wyślij wiadomość do serwera
        public async Task SendToServer(string strInputUser)
        {
            // nic nie rób jeśli wyłana została pusta wiadomość
            if (string.IsNullOrEmpty(strInputUser))
            {
                return;
            }

            // Jeżeli klient istnieje
            if (mClient != null)
            {
                // i klient jest podłączony do serwera
                if (mClient.Connected)
                {
                    // stworz stream writera wykorzystując network stream klienta
                    StreamWriter clientStreamWriter = new StreamWriter(mClient.GetStream())
                    {
                        // włącz czyszczenie bufora
                        AutoFlush = true
                    };

                    // wyślij dane do serwera asynchronicznie
                    await clientStreamWriter.WriteAsync(strInputUser);
                    // zgłoś zdarzenie o wysłaniu wiadomości do klienta
                    OnRaiseTextSendEvent(new TextSendEventArgs(mClient.Client.RemoteEndPoint.ToString(), strInputUser));
                }
            }
        }

        // Zamknij i rozłącz klinta
        public void DisconnectFromServer()
        {
            // jeżeli klient istnieje
            if (mClient != null)
            {
                // i jest podłączony
                if (mClient.Connected)
                {
                    // rorzłącz klienta od serwera (zamknij połączenie)
                    mClient.Close();
                }
                // zgłoś zdarzenie o odłączeniu się od klienta
                OnRaiseServerDisconnectedEvent(new ServerDisconnectedEventArgs(mServerIpAddress.ToString(), mServerPort.ToString()));
            }
        }
    }
}
