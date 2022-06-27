using FootallMatchPredictionApp.Models;
using FootallMatchPredictionApp.Services;
using FootallMatchPredictionApp.Views;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootallMatchPredictionApp
{
    public partial class App : Application
    {
        static FixtureDataStore database;
        static FootballAPI API;
        public static FixtureDataStore Database
        {
            get
            {
                if(database == null)
                {
                    database = new FixtureDataStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fixtures.db"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<FixtureDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
