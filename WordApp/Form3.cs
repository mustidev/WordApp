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

namespace WordApp
{
    public partial class Form3 : Form
    {
        private Button[] buttons;
        private string[] words;
        private Random rand;
        private Button randomButton;        
        public Form3()
        {
            InitializeComponent();

            words = new string[] { "Okul", "Doktor", "Gözlük", "Kalem", "Yuvarlak", "Bardak", "Kartal", "Bilgisayar", "Trafik" };
            buttons = new Button[] { button1, button2, button3, button4 };
            rand = new Random();
            SetRandomWords();
            

        }

        private void SetRandomWords()
        {
            var shuffledWords = words.OrderBy(x => rand.Next()).ToArray();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = shuffledWords[i];
            }
                                
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        public void seslendir()
        {   
              randomButton = buttons[rand.Next(buttons.Length)];


            SpVoice dinle = new SpVoice();
            dinle.Speak(randomButton.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

 
        private void button10_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {   
            seslendir();
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {
                
                MessageBox.Show("Doğru!");
            }
            else
            {
               
                MessageBox.Show("Yanlış!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {

                MessageBox.Show("Doğru!");
            }
            else
            {

                MessageBox.Show("Yanlış!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {

                MessageBox.Show("Doğru!");
            }
            else
            {

                MessageBox.Show("Yanlış!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {

                MessageBox.Show("Doğru!");
            }
            else
            {

                MessageBox.Show("Yanlış!");
            }
        }
    }
}
