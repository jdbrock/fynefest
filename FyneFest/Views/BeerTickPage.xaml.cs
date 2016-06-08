using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FyneFest
{
    public partial class BeerTickPage : ContentPage
    {
        public BeerTickPageViewModel ViewModel { get { return (BeerTickPageViewModel)BindingContext; } set { BindingContext = value; } }

        public BeerTickPage(Beer inBeer)
        {
            InitializeComponent();

            ViewModel = new BeerTickPageViewModel
            {
                Beer = inBeer,
                TickRating = 4 // Default to 4
            };

            if (inBeer.MetaData.IsTicked)
            {
                ViewModel.TickComments = inBeer.MetaData.TickComments;
                ViewModel.TickRating   = inBeer.MetaData.TickRating;
            }
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
//            ViewModel.Beer.MetaData.IsTicked     = true;
            ViewModel.Beer.MetaData.TickComments = ViewModel.TickComments;
            ViewModel.Beer.MetaData.TickRating   = ViewModel.TickRating;
            ViewModel.Beer.MetaData.TickDate     = DateTime.UtcNow;

            await Navigation.PopAsync();
        }

        //private async void OnBeerFavorite(object sender, EventArgs e)
        //{
        //    var item = (BindableObject)sender;
        //    var beer = (Beer)item.BindingContext;

        //    beer.IsFavorited = !beer.IsFavorited;
        //}

        //private async void OnBeerSelected(object sender, EventArgs e)
        //{
        //    var item = (BindableObject)sender;
        //    var beer = (Beer)item.BindingContext;

        //    Navigation.PushAsync(new BeerTickPage());
        //}
    }
}
