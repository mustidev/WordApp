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

namespace WordApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            web.ScriptErrorsSuppressed = true;
            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
            this.Controls.Add(web);
            web.Navigate("https://www.bing.com/translator?to=tr&setlang=tr");

        }
        WebBrowser web = new WebBrowser();
        private void button10_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            web.Document.GetElementById("tta_playconsrc").InvokeMember("Click");
        }
        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                web.Document.GetElementById("tta_input_ta").InnerText = label2.Text;
                web.Document.GetElementById("tta_src_copy").InvokeMember("click");
                web.Document.GetElementById("tta_play_img").InvokeMember("click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)

        {
            try
            {
                web.Navigate("https://www.bing.com/translator?to=tr&setlang=tr");
                web.ScriptErrorsSuppressed = true;
                web.Document.GetElementById("tta_input_ta").InnerText = label2.Text;    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
            
        }


    }
}
