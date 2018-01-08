namespace TCPServer01
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClientPanel = new System.Windows.Forms.Panel();
            this.PortLbl = new System.Windows.Forms.Label();
            this.IpLbl = new System.Windows.Forms.Label();
            this.PortUpDown = new System.Windows.Forms.NumericUpDown();
            this.IPTxtBox = new System.Windows.Forms.TextBox();
            this.MessageRcvListBox = new System.Windows.Forms.ListBox();
            this.MessageReceivedLbl = new System.Windows.Forms.Label();
            this.LogLbl = new System.Windows.Forms.Label();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.MessageSendTxtBox = new System.Windows.Forms.TextBox();
            this.MessageLbl = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.Send2AllBtn = new System.Windows.Forms.Button();
            this.SrvStopBtn = new System.Windows.Forms.Button();
            this.SrvStartBtn = new System.Windows.Forms.Button();
            this.ClearMsgRcvdBtn = new System.Windows.Forms.Button();
            this.ClientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientPanel
            // 
            this.ClientPanel.Controls.Add(this.PortLbl);
            this.ClientPanel.Controls.Add(this.IpLbl);
            this.ClientPanel.Controls.Add(this.PortUpDown);
            this.ClientPanel.Controls.Add(this.IPTxtBox);
            this.ClientPanel.Controls.Add(this.MessageRcvListBox);
            this.ClientPanel.Controls.Add(this.MessageReceivedLbl);
            this.ClientPanel.Controls.Add(this.LogLbl);
            this.ClientPanel.Controls.Add(this.LogListBox);
            this.ClientPanel.Controls.Add(this.MessageSendTxtBox);
            this.ClientPanel.Controls.Add(this.MessageLbl);
            this.ClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientPanel.Location = new System.Drawing.Point(0, 0);
            this.ClientPanel.Name = "ClientPanel";
            this.ClientPanel.Size = new System.Drawing.Size(1023, 559);
            this.ClientPanel.TabIndex = 4;
            // 
            // PortLbl
            // 
            this.PortLbl.AutoSize = true;
            this.PortLbl.Location = new System.Drawing.Point(115, 9);
            this.PortLbl.Name = "PortLbl";
            this.PortLbl.Size = new System.Drawing.Size(26, 13);
            this.PortLbl.TabIndex = 10;
            this.PortLbl.Text = "Port";
            // 
            // IpLbl
            // 
            this.IpLbl.AutoSize = true;
            this.IpLbl.Location = new System.Drawing.Point(9, 9);
            this.IpLbl.Name = "IpLbl";
            this.IpLbl.Size = new System.Drawing.Size(17, 13);
            this.IpLbl.TabIndex = 9;
            this.IpLbl.Text = "IP";
            // 
            // PortUpDown
            // 
            this.PortUpDown.Location = new System.Drawing.Point(118, 25);
            this.PortUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortUpDown.Name = "PortUpDown";
            this.PortUpDown.Size = new System.Drawing.Size(59, 20);
            this.PortUpDown.TabIndex = 8;
            this.PortUpDown.Value = new decimal(new int[] {
            23000,
            0,
            0,
            0});
            // 
            // IPTxtBox
            // 
            this.IPTxtBox.Location = new System.Drawing.Point(12, 25);
            this.IPTxtBox.Name = "IPTxtBox";
            this.IPTxtBox.Size = new System.Drawing.Size(100, 20);
            this.IPTxtBox.TabIndex = 7;
            // 
            // MessageRcvListBox
            // 
            this.MessageRcvListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageRcvListBox.FormattingEnabled = true;
            this.MessageRcvListBox.Location = new System.Drawing.Point(12, 68);
            this.MessageRcvListBox.Name = "MessageRcvListBox";
            this.MessageRcvListBox.Size = new System.Drawing.Size(999, 251);
            this.MessageRcvListBox.TabIndex = 5;
            // 
            // MessageReceivedLbl
            // 
            this.MessageReceivedLbl.AutoSize = true;
            this.MessageReceivedLbl.Location = new System.Drawing.Point(9, 52);
            this.MessageReceivedLbl.Name = "MessageReceivedLbl";
            this.MessageReceivedLbl.Size = new System.Drawing.Size(103, 13);
            this.MessageReceivedLbl.TabIndex = 4;
            this.MessageReceivedLbl.Text = "Received messages";
            // 
            // LogLbl
            // 
            this.LogLbl.AutoSize = true;
            this.LogLbl.Location = new System.Drawing.Point(9, 330);
            this.LogLbl.Name = "LogLbl";
            this.LogLbl.Size = new System.Drawing.Size(25, 13);
            this.LogLbl.TabIndex = 3;
            this.LogLbl.Text = "Log";
            // 
            // LogListBox
            // 
            this.LogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(12, 346);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(999, 199);
            this.LogListBox.TabIndex = 2;
            // 
            // MessageSendTxtBox
            // 
            this.MessageSendTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageSendTxtBox.Location = new System.Drawing.Point(183, 25);
            this.MessageSendTxtBox.Name = "MessageSendTxtBox";
            this.MessageSendTxtBox.Size = new System.Drawing.Size(828, 20);
            this.MessageSendTxtBox.TabIndex = 1;
            // 
            // MessageLbl
            // 
            this.MessageLbl.AutoSize = true;
            this.MessageLbl.Location = new System.Drawing.Point(180, 9);
            this.MessageLbl.Name = "MessageLbl";
            this.MessageLbl.Size = new System.Drawing.Size(50, 13);
            this.MessageLbl.TabIndex = 0;
            this.MessageLbl.Text = "Message";
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.ClearMsgRcvdBtn);
            this.BottomPanel.Controls.Add(this.Send2AllBtn);
            this.BottomPanel.Controls.Add(this.SrvStopBtn);
            this.BottomPanel.Controls.Add(this.SrvStartBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 559);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1023, 50);
            this.BottomPanel.TabIndex = 3;
            // 
            // Send2AllBtn
            // 
            this.Send2AllBtn.Location = new System.Drawing.Point(172, 6);
            this.Send2AllBtn.Name = "Send2AllBtn";
            this.Send2AllBtn.Size = new System.Drawing.Size(75, 41);
            this.Send2AllBtn.TabIndex = 2;
            this.Send2AllBtn.Text = "Send 2 All";
            this.Send2AllBtn.UseVisualStyleBackColor = true;
            this.Send2AllBtn.Click += new System.EventHandler(this.Send2AllBtn_Click);
            // 
            // SrvStopBtn
            // 
            this.SrvStopBtn.Location = new System.Drawing.Point(91, 6);
            this.SrvStopBtn.Name = "SrvStopBtn";
            this.SrvStopBtn.Size = new System.Drawing.Size(75, 41);
            this.SrvStopBtn.TabIndex = 1;
            this.SrvStopBtn.Text = "Stop";
            this.SrvStopBtn.UseVisualStyleBackColor = true;
            this.SrvStopBtn.Click += new System.EventHandler(this.SrvStopBtn_Click);
            // 
            // SrvStartBtn
            // 
            this.SrvStartBtn.Location = new System.Drawing.Point(12, 6);
            this.SrvStartBtn.Name = "SrvStartBtn";
            this.SrvStartBtn.Size = new System.Drawing.Size(75, 41);
            this.SrvStartBtn.TabIndex = 0;
            this.SrvStartBtn.Text = "Start";
            this.SrvStartBtn.UseVisualStyleBackColor = true;
            this.SrvStartBtn.Click += new System.EventHandler(this.SrvStartBtn_Click);
            // 
            // ClearMsgRcvdBtn
            // 
            this.ClearMsgRcvdBtn.Location = new System.Drawing.Point(253, 6);
            this.ClearMsgRcvdBtn.Name = "ClearMsgRcvdBtn";
            this.ClearMsgRcvdBtn.Size = new System.Drawing.Size(110, 41);
            this.ClearMsgRcvdBtn.TabIndex = 3;
            this.ClearMsgRcvdBtn.Text = "Clear Msg Recived ";
            this.ClearMsgRcvdBtn.UseVisualStyleBackColor = true;
            this.ClearMsgRcvdBtn.Click += new System.EventHandler(this.ClearMsgRcvdBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 609);
            this.Controls.Add(this.ClientPanel);
            this.Controls.Add(this.BottomPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ClientPanel.ResumeLayout(false);
            this.ClientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ClientPanel;
        private System.Windows.Forms.ListBox MessageRcvListBox;
        private System.Windows.Forms.Label MessageReceivedLbl;
        private System.Windows.Forms.Label LogLbl;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.TextBox MessageSendTxtBox;
        private System.Windows.Forms.Label MessageLbl;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button Send2AllBtn;
        private System.Windows.Forms.Button SrvStopBtn;
        private System.Windows.Forms.Button SrvStartBtn;
        private System.Windows.Forms.Label PortLbl;
        private System.Windows.Forms.Label IpLbl;
        private System.Windows.Forms.NumericUpDown PortUpDown;
        private System.Windows.Forms.TextBox IPTxtBox;
        private System.Windows.Forms.Button ClearMsgRcvdBtn;
    }
}

