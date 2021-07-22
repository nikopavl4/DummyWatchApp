using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Tizen.Wearable.CircularUI.Forms;

using SQLite;
using QuoteS.Classes;

namespace TizenUno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {

        public Favorites()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<QuoteSi>();
                var quotes = conn.Table<QuoteSi>().ToList();
                mylistview.ItemsSource = quotes;
            }
        }


        private void Back_Clicked(object sender, EventArgs e)
        {

            Application.Current.MainPage = new Fact();
        }
    }
}