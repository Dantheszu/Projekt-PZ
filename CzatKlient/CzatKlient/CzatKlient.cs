using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;using System.Collections;using System.IO;

namespace CzatKlient
{

    public partial class CzatKlient : Form
    {

        private TcpClient client;
        private string addressIPServer = "127.0.0.1";
        private BinaryWriter write;
        private bool isActive = false;


        delegate void SetTextCallBack(ListBox lista, string tekst);
        private void SetText(ListBox lista, string tekst)
        {
            if (lista.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { lista, tekst });
            }
            else
            {
                lista.Items.Add(tekst);
            }
        }
        delegate void SetTextHTMLCallBack(string tekst);
        private void SetTextHTML(string tekst)
        {
            if (webBrowserChat.InvokeRequired)
            {
                SetTextHTMLCallBack f = new SetTextHTMLCallBack(SetTextHTML);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.webBrowserChat.Document.Write(tekst);
            }
        }
        delegate void SetScrollCallBack();
        private void SetScroll()
        {
            if (webBrowserChat.InvokeRequired)
            {
                SetScrollCallBack f = new SetScrollCallBack(SetScroll);
                this.Invoke(f);
            }
            else
            {
                this.webBrowserChat.Document.Window.ScrollTo(1, int.MaxValue);
            }
        }

        private void AddText(string who, string message)
        {
            SetTextHTML("<table><tr><td width=\"10%\"><b>[" + who + "]:</ b ></ td > ");          
            SetTextHTML("<td colspan=2>" + message + "</td></tr></table>");
            SetScroll();
        }

        public CzatKlient()
        {
            InitializeComponent();
            this.webBrowserChat.Navigate("about:blank");
            webBrowserChat.Document.Write("<html><head><style>body,table´{font - size: 10pt; font - family: Verdana; margin: 3px 3px 3px 3px;´font - color: black; }</ style ></ head >< body width =\"" + (webBrowserChat.ClientSize.Width - 20).ToString() + "\">");
        }


        private void backgroundWorkerMainThread_DoWork(object sender, DoWorkEventArgs e)
        {
            UdpClient client = new UdpClient(25000);
            IPEndPoint addressIP = new IPEndPoint(IPAddress.Parse(addressIPServer), 0);
            string message = "";
            while (!backgroundWorkerMainThread.CancellationPending)
                
 {
                Byte[] bufor = client.Receive(ref addressIP);
                string data = Encoding.UTF8.GetString(bufor);
                string[] cmd = data.Split(new char[] { ':' });
                if (cmd[1] == "BYE")
                {
                    AddText("system", "klient odłączony");
                    client.Close();
                    return;
                }
                if (cmd.Length > 2)
                {
                    message = cmd[2];
                    for (int i = 3; i < cmd.Length; i++)
                        message += ":" + cmd[i];
                }
                AddText(cmd[0], message);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNick.Text != String.Empty)
                {
                    client = new TcpClient(addressIPServer, 25000);
                    textBoxNick.ReadOnly = true;
                    NetworkStream ns = client.GetStream();
                    write = new BinaryWriter(ns);
                    write.Write(textBoxNick.Text + ":HI:" + "pusty");
                    BinaryReader read = new BinaryReader(ns);
                    string answer = read.ReadString();
                    if (answer == "HI")
                    {
                        backgroundWorkerMainThread.RunWorkerAsync();
                        isActive = true;
                        buttonConnect.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Serwer odmawia nawiązania połączenia");
                        buttonConnect.Enabled = true;
                        client.Close();
                    }
                }
                else
                    MessageBox.Show("Wpisz swój nick");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie można nawiązać połączenia " + ex.Message);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (isActive && textBoxMessage.Text != String.Empty)
                write.Write(textBoxNick.Text + ":SAY:" + textBoxMessage.Text);
            textBoxMessage.Text = String.Empty;
        }

        

        private void CzatKlient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (write != null)
            {
                try
                {
                    write.Write(textBoxNick.Text + ":BYE:" + "pusty");
                    write.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Błąd");
                }
            }
            if (backgroundWorkerMainThread.IsBusy)
                backgroundWorkerMainThread.CancelAsync();
            if (client != null)
                client.Close();
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
