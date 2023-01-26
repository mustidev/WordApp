using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;
using System.Data.SqlClient;


namespace HearTS
{
    public partial class Form3 : Form
    {
        private Button[] buttons;
        private Random rand;
        private Button randomButton;
        List<string> wordList = new List<string>();

        public Form3()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            wordDB(); //database den kelime listesini çekmek için

            buttons = new Button[] { button1, button2, button3, button4 };
            rand = new Random();
            SetRandomWords();
            

        }

        private void SetRandomWords()
        {
            var shuffledWords = wordList.OrderBy(x => rand.Next()).ToArray();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = shuffledWords[i];
            }
                                
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ButtonDisable();
        }
        private async void seslendir()
        {   
            
            randomButton = buttons[rand.Next(buttons.Length)];

            // Azure Speech Services kullanmak için gerekli olan kimlik bilgileri
            string subscriptionKey = "37acc756bb794815b919566626818017";
            string serviceRegion = "eastus";

            var config = SpeechConfig.FromSubscription(subscriptionKey, serviceRegion);
            config.SpeechSynthesisLanguage = "tr-TR";
            var synthesizer = new SpeechSynthesizer(config);            
            var result = await synthesizer.SpeakTextAsync(randomButton.Text);

            if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");
            }
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

            ButtonEnable();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {

                MessageBox.Show("Doğru!");
                SetRandomWords();

                ButtonDisable();

                System.Threading.Thread.Sleep(1000);

                seslendir();

                ButtonEnable();

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

                ButtonDisable();

                System.Threading.Thread.Sleep(2000);

                seslendir();

                ButtonEnable();
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

                ButtonDisable();

                System.Threading.Thread.Sleep(2000);

                seslendir();

                ButtonEnable();

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

                ButtonDisable();

                System.Threading.Thread.Sleep(2000);

                seslendir();

                ButtonEnable();
    
            }
            else
            {

                MessageBox.Show("Yanlış!");
            }
        }

        private void ButtonEnable()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void ButtonDisable()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void wordDB()
        {

            string connectionString = "Data Source=DESKTOP-1P312F6;Initial Catalog=word;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM wordTable", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            wordList.Add(reader["words"].ToString());
                        }

                        // words dizisi SQL veritabanından çekilmiş kelimelerle doldurulmuş olacak
                        connection.Close();
                    }
                }
            }

        }
    }
}
