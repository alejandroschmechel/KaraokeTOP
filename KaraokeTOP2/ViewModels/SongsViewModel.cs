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
    public class SongsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Songs { get; set; }
        public ICommand LoadMoreSongsCommand { get; set; }

        public SongsViewModel()
        {
            LoadMoreSongsCommand = new Command(LoadSongs);
            Title = "Lista de Músicas";
            Songs = new ObservableCollection<Item>();
            LoadSongs();
        }

        private async void LoadSongs()
        {
            var songs = await App.SongRepo.GetSongsAlphabeticalPagged(Songs.Count);
            foreach (var song in songs)
            {
                Songs.Add(song);
                Debug.WriteLine("Added: " + song.Artist + " - " + song.SongName);
            }
        }
    }
}
