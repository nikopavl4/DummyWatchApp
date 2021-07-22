using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLitePCL;
using SQLite;
using System.IO;

using QuoteS.Classes;

namespace TizenUno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public static string FilePath;

        const string databaseFileName = "SQLite3.db3";
        static string databasePath;
        string dataPath = global::Tizen.Applications.Application.Current.DirectoryInfo.Data;

        public void InitiateSQLite()
        {
            databasePath = Path.Combine(dataPath, databaseFileName);
        }



        public App()
        {
            InitiateSQLite();

            InitializeComponent();

            MainPage = new TizenUno.MainPage();

            FilePath = databasePath;
        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

