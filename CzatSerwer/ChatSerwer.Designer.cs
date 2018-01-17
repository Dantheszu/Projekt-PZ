namespace CzatSerwer
{
    partial class ChatSerwer
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
            this.groupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxSerwer = new System.Windows.Forms.ListBox();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxIpAddress = new System.Windows.Forms.ComboBox();
            this.webBrowserChat = new System.Windows.Forms.WebBrowser();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.backgroundWorkerMainLoop = new System.ComponentModel.BackgroundWorker();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBoxAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAdmin
            // 
            this.groupBoxAdmin.Controls.Add(this.buttonRemove);
            this.groupBoxAdmin.Controls.Add(this.listBoxUsers);
            this.groupBoxAdmin.Controls.Add(this.buttonStop);
            this.groupBoxAdmin.Controls.Add(this.buttonStart);
            this.groupBoxAdmin.Controls.Add(this.label2);
            this.groupBoxAdmin.Controls.Add(this.listBoxSerwer);
            this.groupBoxAdmin.Controls.Add(this.numericUpDownPort);
            this.groupBoxAdmin.Controls.Add(this.label1);
            this.groupBoxAdmin.Controls.Add(this.comboBoxIpAddress);
            this.groupBoxAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxAdmin.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAdmin.Name = "groupBoxAdmin";
            this.groupBoxAdmin.Size = new System.Drawing.Size(212, 479);
            this.groupBoxAdmin.TabIndex = 0;
            this.groupBoxAdmin.TabStop = false;
            this.groupBoxAdmin.Text = "Panel Administracyjny";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(9, 447);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 26);
            this.buttonRemove.TabIndex = 8;
            this.buttonRemove.Text = "Usuń";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 16;
            this.listBoxUsers.Location = new System.Drawing.Point(95, 277);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(110, 196);
            this.listBoxUsers.TabIndex = 7;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(130, 244);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 244);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // listBoxSerwer
            // 
            this.listBoxSerwer.FormattingEnabled = true;
            this.listBoxSerwer.ItemHeight = 16;
            this.listBoxSerwer.Location = new System.Drawing.Point(6, 127);
            this.listBoxSerwer.Name = "listBoxSerwer";
            this.listBoxSerwer.Size = new System.Drawing.Size(199, 100);
            this.listBoxSerwer.TabIndex = 3;
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(85, 76);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownPort.TabIndex = 2;
            this.numericUpDownPort.Value = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Adress:";
            // 
            // comboBoxIpAddress
            // 
            this.comboBoxIpAddress.FormattingEnabled = true;
            this.comboBoxIpAddress.Location = new System.Drawing.Point(85, 35);
            this.comboBoxIpAddress.Name = "comboBoxIpAddress";
            this.comboBoxIpAddress.Size = new System.Drawing.Size(121, 24);
            this.comboBoxIpAddress.TabIndex = 0;
            this.comboBoxIpAddress.Text = "127.0.0.1";
            // 
            // webBrowserChat
            // 
            this.webBrowserChat.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserChat.Location = new System.Drawing.Point(258, 25);
            this.webBrowserChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserChat.Name = "webBrowserChat";
            this.webBrowserChat.Size = new System.Drawing.Size(453, 460);
            this.webBrowserChat.TabIndex = 1;
            this.webBrowserChat.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowserChat.WebBrowserShortcutsEnabled = false;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(114, 512);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(582, 20);
            this.textBoxMessage.TabIndex = 2;
            this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown_1);
            // 
            // backgroundWorkerMainLoop
            // 
            this.backgroundWorkerMainLoop.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMainLoop_DoWork);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(21, 512);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Wyślij";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // ChatSerwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 548);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.webBrowserChat);
            this.Controls.Add(this.groupBoxAdmin);
            this.Name = "ChatSerwer";
            this.Text = "Form1";
            this.groupBoxAdmin.ResumeLayout(false);
            this.groupBoxAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAdmin;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxSerwer;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxIpAddress;
        private System.Windows.Forms.WebBrowser webBrowserChat;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMainLoop;
        private System.Windows.Forms.Button buttonSend;
    }
}

