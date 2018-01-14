using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace KomunikatorKlient
{
    
    public partial class KomunikatorKlient : Form
    {

        private TcpClient klient;
        private BinaryWriter pisanie;
        private BinaryReader czytanie;
        private string serwerIP = "127.0.0.1";
        private int PozycjaKursora;
        private bool polaczeniaAktywne;

        delegate void SetTextCallBack(string tekst);
        delegate void SetScrollCallBack();
        private void SetText(string tekst)
        {
            if (listBox1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBox1.Items.Add(tekst);
            }
        }
        private void SetTextHTML(string tekst)
        {
            if (webBrowser1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetTextHTML);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.webBrowser1.Document.Write(tekst);
            }
        }
        private void SetScroll()
        {
            if (webBrowser1.InvokeRequired)
            {
                SetScrollCallBack s = new SetScrollCallBack(SetScroll);
                this.Invoke(s);
            }
            else
            {
                this.webBrowser1.Document.Window.ScrollTo(1, Int32.MaxValue);
            }
        }

        private void WpiszTekst(string kto, string wiadomosc)
        {
            SetTextHTML("<table><tr><td width=\"10%\"><b>" + kto + "</b></td><tdwidth =\"90%\">(" + DateTime.Now.ToShortTimeString() + "):</td></tr>");
            SetTextHTML("<tr><td colspan=2>" + wiadomosc + "</td></tr></table>");
            SetTextHTML("<hr>");
            SetScroll();
        }


        public KomunikatorKlient()
        {
            InitializeComponent();
            this.webBrowser1.Navigate("about:blank");
            this.webBrowser1.Document.Write("<html><head><style>body,table { fontsize:10pt; font - family: Verdana; margin: 3px 3px 3px 3px; font - color:black;}</style></head><body width =\"" + (webBrowser1.ClientSize.Width -20).ToString() + "\">");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                klient = new TcpClient(serwerIP, (int)numericUpDown1.Value);
                NetworkStream ns = klient.GetStream();
                czytanie = new BinaryReader(ns);
                pisanie = new BinaryWriter(ns);
                pisanie.Write("###HI###");
                this.SetText("Autoryzacja ...");
                polaczeniaAktywne = true;
                backgroundWorker2.RunWorkerAsync();
            }
            catch
            {
                this.SetText("Nie można nawiązać połączenia");
                polaczeniaAktywne = false;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            SetText("Autoryzacja zakończona");
            string wiadomosc;
            try
            {
                while ((wiadomosc = czytanie.ReadString()) != "###BYE###")
                {
                    WpiszTekst("ktoś", wiadomosc);
                }
                SetText("Połączenie przerwane");
                polaczeniaAktywne = false;
                klient.Close();
            }
            catch
            {
                SetText("Połączenie z serwerem zostało przerwane");
                polaczeniaAktywne = false;
                klient.Close();
            }
        }

        private void WprowadzTag(string tag)
        {
            string kod = textBox1.Text;
            textBox1.Text = kod.Insert(PozycjaKursora, tag);
            textBox1.Focus();
            if (tag == "<br>" || tag == "<hr>")
            {
                textBox1.Select(PozycjaKursora + tag.Length, 0);
                PozycjaKursora += tag.Length;
            }
            else
            {
                textBox1.Select(PozycjaKursora + tag.Length / 2, 0);
                PozycjaKursora += tag.Length / 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (polaczeniaAktywne == false)
            {
                backgroundWorker1.RunWorkerAsync();
                webBrowser1.Navigate("about:blank");
            }
            else
            {
                polaczeniaAktywne = false;
                if (klient != null)
                {
                    pisanie.Write("###BYE###");
                    klient.Close();
                }
            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            PozycjaKursora = textBox1.SelectionStart;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            PozycjaKursora = textBox1.SelectionStart;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WpiszTekst("ja", textBox1.Text);
            if (polaczeniaAktywne)
                pisanie.Write(textBox1.Text);
            textBox1.Text = "";
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WprowadzTag("<i></i>");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WprowadzTag("<b></b>");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.button2_Click(sender, e);
        }
    }
}
