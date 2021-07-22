using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;
using System.Diagnostics;

using SQLite;
using QuoteS.Classes;

namespace TizenUno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Fact : ContentPage
    {
        public class Quote
        {
            public string text { get; set; }
            public string found { get; set; }
            public string number { get; set; }

            public string type { get; set; }
        }
        public Fact()
        {
            InitializeComponent();
        }




        private async void Get_Clicked(object sender, EventArgs e)
        {
            MYLABEL.Text = await GetFact();
        }

        private void OnHeartClick(object sender, EventArgs e)
        {
            QuoteSi squote = new QuoteSi()
            {
                Message = MYLABEL.Text,
                Number = newnum.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<QuoteSi>();
                int rowsAdded = conn.Insert(squote);
            }


            Application.Current.MainPage = new Favorites();
        }


        async Task<string> GetFact()
        {
            string basicurl = "https://numbersapi.p.rapidapi.com/";
            string num = newnum.Text;
            string endurl = "/trivia?json=true&notfound=floor";
            string finalurl = basicurl + num + endurl;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(finalurl),
                Headers =
                {
                    { "x-rapidapi-key", "141562f162mshef56d35340518cbp106306jsn2a52bee0fe59" },
                    { "x-rapidapi-host", "numbersapi.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(body);
                Quote myquote = JsonConvert.DeserializeObject<Quote>(body);

                return myquote.text;
            }
        }

    }
}