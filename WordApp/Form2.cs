using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
//using System.Speech.Synthesis;

namespace WordApp
{
    public partial class Form2 : Form
    {   

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void words()
        {
            string[] kelimeler = { "Okul", "Doktor", "Gözlük", "Kalem", "Yuvarlak", "Bardak", "Kartal", "Bilgisayar","Trafik" };
            
            button1.Text = kelimeler[0];
            button2.Text = kelimeler[1];
            button3.Text = kelimeler[2];
            button4.Text = kelimeler[3];
            button5.Text = kelimeler[4];
            button6.Text = kelimeler[5];
            button7.Text = kelimeler[6];
            button8.Text = kelimeler[7];
            button9.Text = kelimeler[8];
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            words();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button1.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button2.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button3.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button4.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button5.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button6.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button7.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button8.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SpVoice dinle = new SpVoice();
            dinle.Speak(button9.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }
    }
}
