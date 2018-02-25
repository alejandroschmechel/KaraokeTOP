using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using KaraokeTOP.Models;
using Xamarin.Forms;

namespace KaraokeTOP
{
    public partial class SearchPage : ContentPage, INotifyPropertyChanged
    {
        SearchViewModel viewModel;

        public SearchPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SearchViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        async void FilterSearchResults(object sender, EventArgs e)
        {
            viewModel.Items.Clear();
            ItemsListView.IsVisible = false;
            resultsLabel.IsVisible = false;
            string searchTerm = searchInput.Text;
            var songs = await App.SongRepo.GetFromSearch(searchTerm);
            foreach (var song in songs)
            {
                viewModel.Items.Add(song);
            }
            ItemsListView.IsVisible = true;
            resultsLabel.IsVisible = true;
        }

        async void CheckButton (object sender, TextChangedEventArgs e){
            if (searchInput.Text.Length > 4){
                searchButton.IsEnabled = true;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
