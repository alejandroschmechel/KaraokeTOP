using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using KaraokeTOP.Models;
using Xamarin.Forms;

using System.Windows.Input;

namespace KaraokeTOP
{
    public class ArtistsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Artists { get; set; }
        public ICommand LoadMoreArtistsCommand { get; set; }

        public ArtistsViewModel()
        {
            LoadMoreArtistsCommand = new Command(LoadArtists);
            Title = "Lista de Artistas";
            Artists = new ObservableCollection<Item>();
            LoadArtists();
        }

        private async void LoadArtists()
        {
            var artists = await App.SongRepo.GetArtistsPaged(Artists.Count);
            foreach (var artist in artists)
            {
                Artists.Add(artist);
                Debug.WriteLine("Added: " + artist.Artist);
            }
        }
    }
}
