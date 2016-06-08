using PropertyChanged;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FyneFest
{
    [ImplementPropertyChanged]
    public class BeerPageViewModel
    {
        public Boolean HasDataNote { get { return !String.IsNullOrWhiteSpace(DataNote); } }
        public String DataNote { get; private set; }

        public ObservableCollection<BeerViewModel> Beers { get; private set; }
        public ObservableCollection<BeerViewModel> FilteredBeers { get; private set; }

        public ICommand OrderAZCommand { get; set; }
        public ICommand OrderFavCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public String SearchText { get; set; }

        public MainTabbedPageViewModel Parent { get; set; }

        public BeerPageViewModel(MainTabbedPageViewModel inParent)
        {
            Parent = inParent;

            Beers = new ObservableCollection<BeerViewModel>();
            FilteredBeers = new ObservableCollection<BeerViewModel>();

            OrderAZCommand = new Command(OnOrderAZ);
            OrderFavCommand = new Command(OnOrderFav);

            SearchCommand = new Command(OnSearch);
        }

        public void OnSearch()
        {
            RefreshFilter();
        }

        public void SetOrder(BeerSortOrder inSortOrder)
        {
            switch (inSortOrder)
            {

                case BeerSortOrder.AZ:
                    Beers = new ObservableCollection<BeerViewModel>(Beers
                        .OrderBy(X => X.Beer.BreweryName)
                        .ThenBy(X => X.Beer.BeerName));
                    break;

                case BeerSortOrder.Fav:
                    Beers = new ObservableCollection<BeerViewModel>(Beers
                        .OrderByDescending(X => X.Beer.MetaData.IsFavorited)
                        .ThenBy(X => X.Beer.BreweryName)
                        .ThenBy(X => X.Beer.BeerName));
                    break;
            }
        }

        private void OnOrderFav()
        {
            Parent.SetOrder(BeerSortOrder.Fav);
        }

        private void OnOrderAZ()
        {
            Parent.SetOrder(BeerSortOrder.AZ);
        }

        public void SetNote(String note)
        {
            DataNote = note;
        }

        public void SetBeers(IEnumerable<Beer> inBeers)
        {
            Beers.Clear();

            foreach (var beer in inBeers)
                Beers.Add(new BeerViewModel(beer));

            RefreshFilter();
        }

        public void RefreshFilter()
        {
            FilteredBeers.Clear();

            var beers = Beers
                .OrderBy(X => X.Beer.BreweryName)
                //.ThenBy(X => X.Beer.SessionNumber)
                .ThenBy(X => X.Beer.BeerName);

            foreach (var beer in beers)
            {
                if (String.IsNullOrWhiteSpace(SearchText))
                    FilteredBeers.Add(beer);
                else
                {
                    var split = SearchText.Split(new[] { ' ' });

                    if (split.All(X => beer.Beer.SearchHaystack.ToLower().Contains(X.ToLower()))) // TODO: Add a Contains extension method that suipports OrdinalIgnoreCase.
                        FilteredBeers.Add(beer);
                }
            }
        }

        public void OnSearchTextChanged()
        {
            // Live search disabled.
            // Only using this so we can clear the search once it's cancelled.
            // RefreshFilter ();

            if (String.IsNullOrWhiteSpace(SearchText))
                FilteredBeers = new ObservableCollection<BeerViewModel>(Beers);
        }

        public void Refresh(Action inCallback)
        {
            Parent.Refresh(() =>
           {
               RefreshFilter();
               inCallback();
           });
        }
    }
}