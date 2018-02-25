using System;

using Xamarin.Forms;

namespace KaraokeTOP
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page mainPage, songsPage, artistsPage, searchPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    mainPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Todas as Músicas"
                    };

                    songsPage = new NavigationPage(new SongsPage())
                    {
                        Title = "Por Música"
                    };

                    artistsPage = new NavigationPage(new ArtistsPage())
                    {
                        Title = "Por Artista"
                    };

                    searchPage = new NavigationPage(new SearchPage())
                    {
                        Title = "Buscar"
                    };

                    mainPage.Icon = "playlist.png";
                    songsPage.Icon = "song.png";
                    artistsPage.Icon = "band.png";
                    searchPage.Icon = "magnifier.png";
                    break;

                default:
                    mainPage = new ItemsPage()
                    {
                        Title = "Todas as Musicas"
                    };

                    songsPage = new SongsPage()
                    {
                        Title = "Por Musica"
                    };

                    artistsPage = new ArtistsPage()
                    {
                        Title = "Por Artista"
                    };

                    searchPage = new SearchPage()
                    {
                        Title = "Buscar"
                    };
                    break;
            }

            Children.Add(mainPage);
            Children.Add(songsPage);
            Children.Add(artistsPage);
            Children.Add(searchPage);

            Title = Children[0].Title;
            this.BarTextColor = Color.White;
            this.BarBackgroundColor = Color.FromHex("#5107BA");
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
