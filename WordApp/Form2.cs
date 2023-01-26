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
using Microsoft.CognitiveServices.Speech;
using System.Data.SqlClient;


namespace WordApp
{
    public partial class Form2 : Form
    {

        List<string> wordList = new List<string>();
        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

   
        private void Form2_Load(object sender, EventArgs e)
        {

            wordDB();
           
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in buttons)
            {
                button.Click += new EventHandler(Button_Click);
              
              
            }
            Random rand = new Random();
            List<string> shuffledWords = wordList.OrderBy(x => rand.Next()).ToList();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = shuffledWords[i];
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            // Your subscription key and service region
            string subscriptionKey = "37acc756bb794815b919566626818017";
            string serviceRegion = "eastus";

            // Create a config with the subscription key and service region
            var config = SpeechConfig.FromSubscription(subscriptionKey, serviceRegion);

            // Set the language to Turkish
            config.SpeechSynthesisLanguage = "tr-TR";

            // Create a synthesizer
            var synthesizer = new SpeechSynthesizer(config);

            // Get the text from button
            Button button = (Button)sender;
            string text = button.Text;

            // Speak the text
            var result = await synthesizer.SpeakTextAsync(text);

            // Check for errors

            if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                MessageBox.Show($"CANCELED: Reason={cancellation.Reason}");
            }
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
