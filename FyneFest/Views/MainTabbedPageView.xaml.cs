//using Acr.XamForms.BarCodeScanner;
//using Craft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FyneFest
{
    public partial class MainTabbedPageView
    {
        // ===========================================================================
        // = Public Properties
        // ===========================================================================

        public MainTabbedPageViewModel ViewModel { get { return (MainTabbedPageViewModel)BindingContext; } set { BindingContext = value; } }

        // ===========================================================================
        // = Construction
        // ===========================================================================

        public MainTabbedPageView()
        {
            InitializeComponent();

            ViewModel = new MainTabbedPageViewModel();
        }

        // ===========================================================================
        // = Event Handling
        // ===========================================================================

        //protected override async void OnAppearing()
        //{
        //    await ViewModel.RefreshCheckins();
        //    await ViewModel.RefreshCellar();
        //}

        //private async void OnCellarAddButtonClicked(object sender, EventArgs e)
        //{
        //    await CellarNavigationPage.Navigation.PushAsync(new CellarAddPage());
        //}

        //private async void OnCellarDrink(Object inSender, EventArgs inArgs)
        //{
        //    var menuItem = (MenuItem)inSender;
        //    var stockResult = (StockResult)menuItem.BindingContext;

        //    await ViewModel.DoCellarDrinkCommand(stockResult);
        //}

        //private async void OnCellarScanButtonClicked(object sender, EventArgs e)
        //{
        //    var config = BarCodeReadConfiguration.Default;
        //    config.TryHarder = true;
        //    config.PureBarcode = true;
        //    config.Formats = new List<BarCodeFormat>
        //    {
        //        BarCodeFormat.EAN_13,
        //        BarCodeFormat.EAN_8,
        //        BarCodeFormat.UPC_A,
        //        BarCodeFormat.UPC_E,
        //        BarCodeFormat.UPC_EAN_EXTENSION,
        //        BarCodeFormat.CODE_128,
        //        BarCodeFormat.CODE_39,
        //        BarCodeFormat.CODE_93,
        //        BarCodeFormat.ITF
        //    };

        //    var result = await Services.Barcode.Read();

        //    if (!result.Success)
        //        return;

        //    Device.BeginInvokeOnMainThread(() => ViewModel.IsBusyModal = true);

        //    var beer = await Services.Client.Get<UpcResult>("upc/lookup?id=" + result.Code);

        //    var addPageVM = new CellarAddPageViewModel(beer.BreweryName, beer.BeerName);
        //    var addPage = new CellarAddPage(addPageVM);

        //    await CellarNavigationPage.Navigation.PushAsync(addPage);
        //}
    }
}
