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
    public class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public SearchViewModel()
        {
            Title = "Busca por Músicas/Artistas";
            Items = new ObservableCollection<Item>();
        }

        private async void LoadSongs(string search)
        {
            var songs = await App.SongRepo.GetFromSearch(search);
            foreach (var song in songs)
            {
                Items.Add(song);
                Debug.WriteLine("Added: " + song.Artist + " - " + song.SongName);
            }
        }
    }
}
