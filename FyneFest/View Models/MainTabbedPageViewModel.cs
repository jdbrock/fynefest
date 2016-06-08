using Acr.UserDialogs;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FyneFest
{
    [ImplementPropertyChanged]
    public class MainTabbedPageViewModel
    {
        // ===========================================================================
        // = Private Constants
        // ===========================================================================


        private const String FYNEFEST_INITIAL_INTERNAL_DATA_FILENAME = "fynefest-preload-data.json";
        private const String FYNEFEST_CURRENT_DATA_FILENAME = "fynefest-1.0.0-data.json";
        private const String FYNEFEST_CURRENT_METADATA_FILENAME = "fynefest-1.0.0-metadata.json";

        private const String FYNEFEST_MAIN_DATA_URI = "https://byo.blob.core.windows.net/data-prod/fynefest-1.0.0-dev.json";

        // ===========================================================================
        // = Public Properties
        // ===========================================================================

        public Boolean IsBusyModal { get; set; }

        public static MainTabbedPageViewModel Instance { get; set; }

        public BeerPageViewModel BeerViewModel { get; set; }

        // ===========================================================================
        // = Construction
        // ===========================================================================

        public MainTabbedPageViewModel()
        {
            Instance = this;

            BeerViewModel = new BeerPageViewModel(this);

            CopyInitialData();
            LoadMainData();
        }

        // ===========================================================================
        // = Public Methods
        // ===========================================================================

        public void Refresh(Action inCallback)
        {
            var tmpPath = Path.Combine(GetDocumentsPath(), FYNEFEST_CURRENT_DATA_FILENAME + ".tmp");
            var toPath = Path.Combine(GetDocumentsPath(), FYNEFEST_CURRENT_DATA_FILENAME);

            var client = new WebClient();
            client.DownloadFileCompleted += (S, E) => OnDownloadCompleted(tmpPath, toPath, inCallback, E);
            client.DownloadFileAsync(new Uri(FYNEFEST_MAIN_DATA_URI), tmpPath);
        }

        public void SetOrder(BeerSortOrder inSortOrder)
        {
            BeerViewModel.SetOrder(inSortOrder);
        }

        // ===========================================================================
        // = Private Methods
        // ===========================================================================

        private void CopyInitialData()
        {
            var fromPath = FYNEFEST_INITIAL_INTERNAL_DATA_FILENAME;
            var toPath = Path.Combine(GetDocumentsPath(), FYNEFEST_CURRENT_DATA_FILENAME);

            if (!File.Exists(fromPath))
                return;

            if (File.Exists(toPath))
                return;

            File.Copy(fromPath, toPath);
        }

        private void OnDownloadCompleted(String inFromPath, String inToPath, Action inCallback, AsyncCompletedEventArgs e)
        {
            try
            {
                // Failure
                if (e.Error != null || e.Cancelled)
                {
                    if (File.Exists(inFromPath))
                        File.Delete(inFromPath);

                    inCallback();
                }
                // Success
                else
                {
                    File.Copy(inFromPath, inToPath, true);
                    File.Delete(inFromPath);

                    LoadMainData();
                    inCallback();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.ShowError("Error refreshing beer.");
                inCallback();
            }
        }

        private void LoadMainData()
        {
            var path = Path.Combine(GetDocumentsPath(), FYNEFEST_CURRENT_DATA_FILENAME);

            try
            {
                using (var cbcDataFile = File.OpenText(path))
                {
                    var cbcData = JsonConvert.DeserializeObject<FyneFestData>(cbcDataFile.ReadToEnd());

                    LoadMetaData(cbcData);

                    BeerViewModel.SetBeers(cbcData.Beers);
                    BeerViewModel.SetNote(cbcData.Note);
                }
            }
            catch
            {
                // Just in case we can't load the data (it was corrupted on download).
                File.Delete(path);
                CopyInitialData();
                LoadMainData(); // Will cause a loop if the packaged data is broken.
            }
        }

        private void LoadMetaData(FyneFestData inData)
        {
            var documentsPath = GetDocumentsPath();

            if (File.Exists(Path.Combine(documentsPath, FYNEFEST_CURRENT_METADATA_FILENAME)))
            {
                var beersById = inData.Beers
                    .ToDictionary(X => X.Id);

                using (var metaDataFile = File.OpenText(Path.Combine(documentsPath, FYNEFEST_CURRENT_METADATA_FILENAME)))
                {
                    var metadata = JsonConvert.DeserializeObject<FyneFestMetaData>(metaDataFile.ReadToEnd());

                    foreach (var beerMetaData in metadata.BeerMetaData)
                        beersById[beerMetaData.BeerId].MetaData = beerMetaData;
                }
            }
        }

        public void SaveMetaData()
        {
            var metaData = new FyneFestMetaData();

            var beerViewModels = new[]
            {
                BeerViewModel
            };

            foreach (var viewModel in beerViewModels)
                foreach (var beer in viewModel.Beers)
                {
                    if (beer.Beer.MetaData.IsEmpty)
                        continue;

                    beer.Beer.MetaData.BeerId = beer.Beer.Id;
                    metaData.BeerMetaData.Add(beer.Beer.MetaData);
                }

            var documentsPath = GetDocumentsPath();

            File.WriteAllText(Path.Combine(documentsPath, FYNEFEST_CURRENT_METADATA_FILENAME), JsonConvert.SerializeObject(metaData));
        }

        private String GetDocumentsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
