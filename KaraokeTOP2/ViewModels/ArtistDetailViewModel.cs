using System;
using System.Diagnostics;
using System.Collections.ObjectModel;
using KaraokeTOP.Models;
using Xamarin.Forms;

using System.ComponentModel;
using System.Windows.Input;

namespace KaraokeTOP
{
    public class ArtistDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Songs { get; set; }
        private string _idAndSongName;
        public string IdAndSongName
        {
            get { return _idAndSongName; }
            set
            {
                if (_idAndSongName != value)
                {
                    _idAndSongName = value;
                }
            }
        }

        public ArtistDetailViewModel(Item item = null)
        {
            Songs = new ObservableCollection<Item>();
            Title = item?.Artist;
            LoadSongs(item.Artist);
        }

        public async void LoadSongs(string artist)
        {
            var songs = await App.SongRepo.GetSongsFromArtist(artist);
            foreach (var song in songs)
            {
                Songs.Add(song);
                Debug.WriteLine("Added: " + song.Artist);
            }
        }
    }
}
