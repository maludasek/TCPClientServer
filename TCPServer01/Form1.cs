using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPClientServer;

namespace TCPServer01
{
    public partial class MainForm : Form
    {
        // globalna zmienna mServer
        SocketServerAsync mServer;

        public MainForm()
        {
            // Inicjalizacja komponentów
            InitializeComponent();
            // inicjalizacja mServer
            mServer = new SocketServerAsync();
            // Podłączączenie zdarzeń
            mServer.RaiseClientConnectedEvent += HandleClientConnected;       // Client Connected
            mServer.RaiseTextReceivedEvent += HandleTextReceived;             // Text Received
            mServer.RaiseClientDisconnectedEvent += HandleClientDisconnected; // Client Disconnected
            mServer.RaiseTextSendToAllEvent += HandleTextSendToAll;           // Text Send To All
            mServer.RaiseServerStartEvent += HandleServerStart;               // Server Start
            mServer.RaiseServerStopEvent += HandleServerStop;                 // Server Stop
        }

        // Zdzarzenie Server Stop
        private void HandleServerStop(object sender, ServerStopEventArgs e)
        {
            // Dodaj komunikat do listy Logów
            LogListBox.Items.Add(string.Format("{0} - Server {1}:{2} stopped",
                DateTime.Now.ToString("d"), e.ServerIP, e.Port));
            // Przesuń na koniec listy
            LogListBox.TopIndex = LogListBox.Items.Count - 1;
        }

        // Zdzarzenie Server Start
        private void HandleServerStart(object sender, ServerStartEventArgs e)
        {
            // Dodaj komunikat do listy Logów
            LogListBox.Items.Add(string.Format("{0} - Server {1}:{2} started",
                DateTime.Now.ToString("d"), e.ServerIP, e.Port));
            // Przesuń na koniec listy
            LogListBox.TopIndex = LogListBox.Items.Count - 1;
        }

        // Zdzarzenie SendToAll
        private void HandleTextSendToAll(object sender, TextSendToAllEventArgs e)
        {
            // Dodaj komunikat do listy Logów
            LogListBox.Items.Add(string.Format("{0} - Message sent to all: {1}",
                DateTime.Now.ToString("d"), e.TextSend));
            // Przesuń na koniec listy
            LogListBox.TopIndex = LogListBox.Items.Count - 1;
        }

        // Zdzarzenie Client Disconnected
        private void HandleClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            // Dodaj komunikat do listy Logów
            LogListBox.Items.Add(string.Format("{0} - Client disconnected: {1}, # of clients connected left: {2}",
                DateTime.Now.ToString("d"), e.OldClient, e.ClientCount));
            // Przesuń na koniec listy
            LogListBox.TopIndex = LogListBox.Items.Count - 1;
        }

        // Zdzarzenie Server Text Received
        private void HandleTextReceived(object sender, TextReceivedEventArgs e)
        {
            // Dodaj komunikat do listy otrzymanych wiadomości
            MessageRcvListBox.Items.Add(string.Format("{0} - Received from {1}: {2}",
                DateTime.Now.ToString("d"), e.ClientSender, e.TextReceived));
            // Przesuń na koniec listy
            MessageRcvListBox.TopIndex = MessageRcvListBox.Items.Count - 1;
        }

        // Zdzarzenie Client Connected
        private void HandleClientConnected(object sender, ClientConnectedEventArgs e)
        {
            // Dodaj komunikat do listy Logów
            LogListBox.Items.Add(string.Format("{0} - New client connected: {1}, # of clients connected left: {2}",
                DateTime.Now.ToString("d"), e.NewClient, e.ClientCount));
            // Przesuń na koniec listy
            LogListBox.TopIndex = LogListBox.Items.Count - 1;
        }

        // Zdzarzenie Zamknięcie Formy (programu)
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Zatrzymaj serwer
            mServer.ServerStop();
        }

        // Zdzarzenie Naciśnięcie klawisza SrvStartBtn
        private void SrvStartBtn_Click(object sender, EventArgs e)
        {
            // Konwersja tekstu z IPTxtBox na Adres IP
            IPAddress.TryParse(IPTxtBox.Text, out IPAddress testIP);
            // Sprawdź czy testowane IP przynależy do grupy InterNetwork
            if (testIP.AddressFamily == AddressFamily.InterNetwork)
            {
                // Jeśli tak to wystartuj serwer z tym IP
                mServer.ServerStart(testIP, (int)PortUpDown.Value);
            }
            else
            {
                // Jeśli nie to wystartuj serwer nasłuchując na wszystkich dostępnych IP
                IPTxtBox.Text = "0.0.0.0";
                mServer.ServerStart(null, (int)PortUpDown.Value);
            }
        }

        // Zdzarzenie Naciśnięcie klawisza SrvStopBtn
        private void SrvStopBtn_Click(object sender, EventArgs e)
        {
            // Start servera
            mServer.ServerStop();
        }

        // Zdzarzenie Naciśnięcie klawisza SendToAll
        private void Send2AllBtn_Click(object sender, EventArgs e)
        {
            // Wysłanie do wszystkich wiadomości
            mServer.SendToAll(MessageSendTxtBox.Text.Trim());
        }

        // Zdzarzenie Ładowanie formy (programu)
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Odszukanie i przypisanie do IPTxtBox pierwszego znalezionego IP przynależnego do grupy InterNetwork
            IPTxtBox.Text = Dns.GetHostAddresses(Dns.GetHostName()).Where(addrf => addrf.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
        }

        private void ClearMsgRcvdBtn_Click(object sender, EventArgs e)
        {
            MessageRcvListBox.Items.Clear();
        }
    }
}
