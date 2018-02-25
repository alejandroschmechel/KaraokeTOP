using System;
using KaraokeTOP.Models;
using Xamarin.Forms;

namespace KaraokeTOP
{
    public partial class ArtistDetailPage : ContentPage
    {
        ArtistDetailViewModel viewModel;
        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ArtistDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                SongName = "Artist 1",
                Artist = "This is an item description."
            };

            viewModel = new ArtistDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ArtistDetailPage(ArtistDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ArtistsSongListView.SelectedItem = null;
        }
    }
}
