using System;

using Xamarin.Forms;
using KaraokeTOP.Repositories;
using SQLite.Net.Interop;

namespace KaraokeTOP
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public static SongsRepository SongRepo { get; private set; }

        public App(string dbPath, ISQLitePlatform sqlitePlatform)
        {
            InitializeComponent();

            SongRepo = new SongsRepository(sqlitePlatform, dbPath);
            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}
