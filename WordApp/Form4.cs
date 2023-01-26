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
using Microsoft.CognitiveServices.Speech.Audio;
using System.Data.SqlClient;

namespace HearTS
{
    public partial class Form4 : Form
    {       
        private Random rand;
        List<string> wordList = new List<string>();
        public Form4()
        {
            InitializeComponent();
            this.MaximizeBox = false;

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

            rand = new Random();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            

            // Azure Speech Services kullanmak için gerekli olan kimlik bilgileri
            var subscriptionKey = "37acc756bb794815b919566626818017";   
            var region = "eastus";

            var config = SpeechConfig.FromSubscription(subscriptionKey, region);

            config.SpeechRecognitionLanguage = "tr-TR";
            
            using (var recognizer = new SpeechRecognizer(config))
            {

                var result = await recognizer.RecognizeOnceAsync();

                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                   
                    MessageBox.Show(label2.Text.ToLower().ToString());
                    MessageBox.Show(result.Text.ToLower().Substring(0, result.Text.Length - 1));
                    
                    if (result.Text.ToLower().Substring(0, result.Text.Length-1)==(label2.Text.ToLower()))
                    {
                        MessageBox.Show("Doğru!");
                        SetRandomWords();
                    }
                    else
                    {
                        MessageBox.Show("Yanlış! Tekrar Deneyiniz.. ");

                    }
                }

                else if (result.Reason == ResultReason.NoMatch)
                {
                    MessageBox.Show("Üzgünüz, konuşma tanınmadı.");
                }

                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    MessageBox.Show($"Cancelled due to {cancellation.Reason}");
                }
            }

        }

        private void SetRandomWords()
        {
            var shuffledWords = wordList.OrderBy(x => rand.Next()).ToArray();
            for (int i = 0; i < wordList.Count; i++)
            {
                label2.Text = shuffledWords[i];
            }

        }
        private void Form4_Load(object sender, EventArgs e)
                
        {

            SetRandomWords();


        }


    }
}
