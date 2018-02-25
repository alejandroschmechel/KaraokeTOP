using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using KaraokeTOP.Models;
using Xamarin.Forms;

namespace KaraokeTOP
{
    public partial class ArtistsPage : ContentPage, INotifyPropertyChanged
    {
        ArtistsViewModel viewModel;

        public ArtistsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ArtistsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            //item = item.Remove(item.IndexOf(" "));
            if (item == null)
                return;

            await Navigation.PushAsync(new ArtistDetailPage(new ArtistDetailViewModel(item)));

            // Manually deselect item
            ArtistListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
