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
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public ICommand LoadMoreSongsCommand { get; set; }

        public ItemsViewModel()
        {
            LoadMoreSongsCommand = new Command(LoadSongs);
            Title = "Lista de Músicas";
            Items = new ObservableCollection<Item>();
            LoadSongs();
        }

        private async void LoadSongs()
        {
            var songs = await App.SongRepo.GetSongsPagged(Items.Count);
            foreach (var song in songs)
            {
                Items.Add(song);
                Debug.WriteLine("Added: " + song.Artist + " - " + song.SongName);
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                    Debug.WriteLine("Added: " + item.Artist + " - " + item.SongName);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
