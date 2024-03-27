using Newtonsoft.Json;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace lab2
{
    public partial class Form1 : Form
    {
        private HttpClient client;
        private kantor kantor;


        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            kantor = new kantor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            kantor.Baza_Danych.RemoveRange(kantor.Baza_Danych);
            string call = "https://openexchangerates.org/api/latest.json?app_id=facffc6984e348ce9569adc7c1ddaa7c&base=USD";
            string response = await client.GetStringAsync(call);

            Deserializacja deserializacja = JsonConvert.DeserializeObject<Deserializacja>(response);

            // Przechodzimy przez każdy element zdeserializowanego obiektu i zapisujemy do bazy danych
            foreach (var rate in deserializacja.Rates)
            {

                var newRate = new info_walut()
                {
                    WalutaDb = rate.Key,
                    WartoscDb = rate.Value
                };


                kantor.Baza_Danych.Add(newRate);
            }


            kantor.SaveChanges();
            listBox1.DataSource = kantor.Baza_Danych.Select(i => $"{i.Index}: {i.WalutaDb} - {i.WartoscDb}").ToList();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            kantor.Baza_Danych.Add(new info_walut() { WalutaDb = textBox1.Text, WartoscDb = float.Parse(textBox2.Text) });
            kantor.SaveChanges();
            listBox2.DataSource = kantor.Baza_Danych.Select(i => $"{i.Index}: {i.WalutaDb} - {i.WartoscDb}").ToList();
            listBox2.DisplayMember = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string wpisanaWaluta = textBox3.Text;

            var doUsuniecia = kantor.Baza_Danych.Where(i => i.WalutaDb == wpisanaWaluta).ToList();
            kantor.Baza_Danych.RemoveRange(doUsuniecia);
            kantor.SaveChanges();

            listBox2.DataSource = kantor.Baza_Danych.Select(i => $"{i.Index}: {i.WalutaDb} - {i.WartoscDb}").ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.DisplayMember = null;

            listBox2.DataSource = kantor.Baza_Danych
                .Where(w => w.WartoscDb > 13)
                .Select(w => $"{w.Index}: {w.WalutaDb} - {w.WartoscDb}")
                .ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.DisplayMember = null;

            listBox2.DataSource = kantor.Baza_Danych
                .OrderBy(w => w.WartoscDb)
                .Select(w => $"{w.Index}: {w.WalutaDb} - {w.WartoscDb}")
                .ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string nazwawaluty = textBox4.Text;
            
            var doWyszukania = kantor.Baza_Danych.Where(i => i.WalutaDb == nazwawaluty).ToList();
            listBox2.DataSource = doWyszukania.Select(i => $"{i.Index}: {i.WalutaDb} - {i.WartoscDb}").ToList();
        }
    }


}
