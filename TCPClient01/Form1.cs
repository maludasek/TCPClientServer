using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPClientServer;

namespace TCPClient01
{
    public partial class MainForm : Form
    {
        SocketClientAsync client;

        public MainForm()
        {
            InitializeComponent();
            client = new SocketClientAsync();
            client.RaiseTextReceivedEvent += HandleTextReceived;
            client.RaiseServerConnectedEvent += HandleServerConnected;
            client.RaiseServerDisconnectedEvent += HandleServerDisconnected;
            client.RaiseTextSendEvent += HandleTextSend;
            client.RaiseExceptionEvent += HandleExceptionEvent;
        }

        private void HandleExceptionEvent(object sender, ExceptionEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - {1}: {2}", DateTime.Now, e.Title, e.ExceptionMessage));
        }

        private void HandleTextSend(object sender, TextSendEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - Message sent: {1}, to IP: {2}", DateTime.Now, e.TextSend, e.IpAddress));
        }

        private void HandleServerDisconnected(object sender, ServerDisconnectedEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - Odłączono do serwera: {1}:{2}", DateTime.Now, e.ServerIp, e.ServerPort));
        }

        private void HandleServerConnected(object sender, ServerConnectedEventArgs e)
        {
            LogListBox.Items.Add(string.Format("{0} - Podłączono do serwera: {1}:{2}", DateTime.Now, e.ServerIp, e.ServerPort));
        }

        private void HandleTextReceived(object sender, TextReceivedEventArgs e)
        {
            MessageRcvListBox.Items.Add(string.Format("{0} - {1} sent: {2}", DateTime.Now, e.ClientSender, e.TextReceived));
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (!client.IsConnected)
            {
                client.ConnectToServer(IpHostnameTxtBox.Text, (int)PortUpDown.Value);
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                client.SendToServer(MessageSendTxtBox.Text.Trim());
            }
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            client.DisconnectFromServer();
        }

        private void SendFileBtn_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog SendFileOfd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (SendFileOfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = SendFileOfd.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            if (client.IsConnected)
                            {
                                client.SendToServer(myStream, SendFileOfd.FileName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't open file. Message error: " + ex.Message);
                }
            }
        }
    }
}
