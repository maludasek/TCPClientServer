namespace TCPClient01
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.MessageRcvListBox = new System.Windows.Forms.ListBox();
            this.MessageReceivedLbl = new System.Windows.Forms.Label();
            this.LogLbl = new System.Windows.Forms.Label();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PortUpDown = new System.Windows.Forms.NumericUpDown();
            this.MessageSendTxtBox = new System.Windows.Forms.TextBox();
            this.IpHostnameTxtBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.SendFileBtn = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.MessageRcvListBox);
            this.panel3.Controls.Add(this.MessageReceivedLbl);
            this.panel3.Controls.Add(this.LogLbl);
            this.panel3.Controls.Add(this.LogListBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(692, 471);
            this.panel3.TabIndex = 16;
            // 
            // MessageRcvListBox
            // 
            this.MessageRcvListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageRcvListBox.FormattingEnabled = true;
            this.MessageRcvListBox.Location = new System.Drawing.Point(12, 23);
            this.MessageRcvListBox.Name = "MessageRcvListBox";
            this.MessageRcvListBox.Size = new System.Drawing.Size(674, 251);
            this.MessageRcvListBox.TabIndex = 9;
            // 
            // MessageReceivedLbl
            // 
            this.MessageReceivedLbl.AutoSize = true;
            this.MessageReceivedLbl.Location = new System.Drawing.Point(9, 7);
            this.MessageReceivedLbl.Name = "MessageReceivedLbl";
            this.MessageReceivedLbl.Size = new System.Drawing.Size(103, 13);
            this.MessageReceivedLbl.TabIndex = 8;
            this.MessageReceivedLbl.Text = "Received messages";
            // 
            // LogLbl
            // 
            this.LogLbl.AutoSize = true;
            this.LogLbl.Location = new System.Drawing.Point(9, 285);
            this.LogLbl.Name = "LogLbl";
            this.LogLbl.Size = new System.Drawing.Size(25, 13);
            this.LogLbl.TabIndex = 7;
            this.LogLbl.Text = "Log";
            // 
            // LogListBox
            // 
            this.LogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(12, 301);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(674, 160);
            this.LogListBox.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.PortUpDown);
            this.panel2.Controls.Add(this.MessageSendTxtBox);
            this.panel2.Controls.Add(this.IpHostnameTxtBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 49);
            this.panel2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Server Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Text message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Server IP / Hostname";
            // 
            // PortUpDown
            // 
            this.PortUpDown.Location = new System.Drawing.Point(133, 19);
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
            this.PortUpDown.Size = new System.Drawing.Size(57, 20);
            this.PortUpDown.TabIndex = 12;
            this.PortUpDown.Value = new decimal(new int[] {
            23000,
            0,
            0,
            0});
            // 
            // MessageSendTxtBox
            // 
            this.MessageSendTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageSendTxtBox.Location = new System.Drawing.Point(196, 19);
            this.MessageSendTxtBox.Name = "MessageSendTxtBox";
            this.MessageSendTxtBox.Size = new System.Drawing.Size(490, 20);
            this.MessageSendTxtBox.TabIndex = 11;
            // 
            // IpHostnameTxtBox
            // 
            this.IpHostnameTxtBox.Location = new System.Drawing.Point(6, 19);
            this.IpHostnameTxtBox.Name = "IpHostnameTxtBox";
            this.IpHostnameTxtBox.Size = new System.Drawing.Size(121, 20);
            this.IpHostnameTxtBox.TabIndex = 10;
            this.IpHostnameTxtBox.Text = "127.0.0.1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SendFileBtn);
            this.panel1.Controls.Add(this.ConnectBtn);
            this.panel1.Controls.Add(this.DisconnectBtn);
            this.panel1.Controls.Add(this.SendBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 31);
            this.panel1.TabIndex = 14;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(3, 3);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 3;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.Location = new System.Drawing.Point(84, 3);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(75, 23);
            this.DisconnectBtn.TabIndex = 4;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = true;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(165, 3);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(94, 23);
            this.SendBtn.TabIndex = 5;
            this.SendBtn.Text = "Send message";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // SendFileBtn
            // 
            this.SendFileBtn.Location = new System.Drawing.Point(265, 3);
            this.SendFileBtn.Name = "SendFileBtn";
            this.SendFileBtn.Size = new System.Drawing.Size(94, 23);
            this.SendFileBtn.TabIndex = 6;
            this.SendFileBtn.Text = "Send file";
            this.SendFileBtn.UseVisualStyleBackColor = true;
            this.SendFileBtn.Click += new System.EventHandler(this.SendFileBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 551);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PortUpDown;
        private System.Windows.Forms.TextBox MessageSendTxtBox;
        private System.Windows.Forms.TextBox IpHostnameTxtBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.ListBox MessageRcvListBox;
        private System.Windows.Forms.Label MessageReceivedLbl;
        private System.Windows.Forms.Label LogLbl;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Button SendFileBtn;
    }
}

