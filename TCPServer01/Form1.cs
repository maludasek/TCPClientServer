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
        SocketServerAsync mServer;

        public MainForm()
        {
            InitializeComponent();
            mServer = new SocketServerAsync();
            mServer.RaiseClientConnectedEvent += HandleClientConnected;
            mServer.RaiseTextReceivedEvent += HandleTextReceived;
            mServer.RaiseClientDisconnectedEvent += HandleClientDisconnected;
            mServer.RaiseTextSendToAllEvent += HandleTextSendToAll;
            mServer.RaiseServerStartEvent += HandleServerStart;
            mServer.RaiseServerStopEvent += HandleServerStop;
        }

        private void HandleServerStop(object sender, ServerStopEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - Server {1}:{2} stopped",
                DateTime.Now.ToString("d"), e.ServerIP, e.Port));
        }

        private void HandleServerStart(object sender, ServerStartEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - Server {1}:{2} started",
                DateTime.Now.ToString("d"), e.ServerIP, e.Port));
        }

        private void HandleTextSendToAll(object sender, TextSendToAllEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - Message sent to all: {1}",
                DateTime.Now.ToString("d"), e.TextSend));
        }

        private void HandleClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - Client disconnected: {1}, # of clients connected left: {2}",
                DateTime.Now.ToString("d"), e.OldClient, e.ClientCount));
        }

        private void HandleTextReceived(object sender, TextReceivedEventArgs e)
        {
            MessageRcvListBox.Items.Add(string.Format("{0} - Received from {1}: {2}",
                DateTime.Now.ToString("d"), e.ClientSender, e.TextReceived));
            MessageRcvListBox.TopIndex = MessageRcvListBox.Items.Count - 1;
        }

        private void HandleClientConnected(object sender, ClientConnectedEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - New client connected: {1}, # of clients connected left: {2}",
                DateTime.Now.ToString("d"), e.NewClient, e.ClientCount));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mServer.ServerStop();
        }

        private void SrvStartBtn_Click(object sender, EventArgs e)
        {
            IPAddress.TryParse(IPTxtBox.Text, out IPAddress testIP);
            if (testIP.AddressFamily == AddressFamily.InterNetwork)
            {
                mServer.ServerStart(testIP, (int)PortUpDown.Value);
            }
            else
            {
                IPTxtBox.Text = "0.0.0.0";
                mServer.ServerStart(null, (int)PortUpDown.Value);
            }
        }

        private void SrvStopBtn_Click(object sender, EventArgs e)
        {
            mServer.ServerStop();
        }

        private void Send2AllBtn_Click(object sender, EventArgs e)
        {
            mServer.SendToAll(MessageSendTxtBox.Text.Trim());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IPTxtBox.Text = Dns.GetHostAddresses(Dns.GetHostName()).Where(addrf => addrf.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
        }
    }
}
