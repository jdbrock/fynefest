using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TickerTools.Common;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Net.Code.Csv;
using System.Configuration;
using FyneFest;
using Fizzler.Systems.HtmlAgilityPack;
using System.Net;

namespace FyneFest.Sync
{
    public static class Engine
    {
        // ===========================================================================
        // = Public Properties
        // ===========================================================================
        
        public static HashAlgorithm Hasher { get; } = new SHA256Managed();

        // ===========================================================================
        // = Public Methods
        // ===========================================================================

        public static void Initialize() { }

        public static void SyncFromWeb()
        {
            var beers = LoadFromWeb();

            //MutateForScreenshots(beers);

            var data = new FyneFestData();
            data.Beers.AddRange(beers.OrderBy(X => X.BreweryName).ThenBy(X => X.BeerName));
            //data.Note = "This is a beta beer list. Pull to update.";

            Publish(data);
        }

        // ===========================================================================
        // = Private Methods
        // ===========================================================================
        
        private static IEnumerable<Beer> LoadFromWeb()
        {
            var data = ScrapeHelper.FetchParseAsync("http://www.fynefest.com/?page_id=5", transform: TransformHtml).Result;
            var next = data.QuerySelector("h1");
            string breweryName = "";

            while (next != null)
            {
                if (!next.Name.Equals("p"))
                {
                    next = next.NextSibling;
                    continue;
                }

                if (next.Elements().Any(X => X.Name.Equals("strong", StringComparison.OrdinalIgnoreCase)))
                {
                    breweryName = WebUtility.HtmlDecode(next.Element("strong").InnerText).Trim();

                    if (breweryName.Contains("–"))
                        breweryName = breweryName.Split('–').First().Trim();

                    next = next.NextSibling;
                    continue;
                }

                var record = WebUtility.HtmlDecode(next.InnerText);
                var lines = record.Split(new[] { '\n' });

                var regex = new Regex(@"^(?<beerName>[^–]+?)\s*–?\s*(?<abv>[0-9]+\.?[0-9]*)%?\s*\((?<caskOrKeg>[KC])\)\s*$");
                var match = regex.Match(lines.First());

                if (!match.Success)
                    throw new ApplicationException("Invalid beer: " + lines.First());

                var beerName = match.Groups["beerName"].Value.Trim();
                var abv = Decimal.Parse(match.Groups["abv"].Value.Trim());
                var isCask = match.Groups["caskOrKeg"].Value.Trim() == "C";
                var description = lines.Last().Trim();

                var beer = new Beer
                {
                    BreweryName = breweryName,
                    BeerName = beerName,
                    ABV = abv,
                    Id = $"{breweryName}$$${beerName}$$${abv}$$${isCask}",
                    StyleName = description
                };

                next = next.NextSibling;

                yield return beer;
            }
        }

        private static string TransformHtml(string html)
        {
            return html
                .Replace("<b>", "<strong>", StringComparison.OrdinalIgnoreCase)
                .Replace("</b>", "</strong>", StringComparison.OrdinalIgnoreCase);
        }

        private static void MutateForScreenshots(List<Beer> beers)
        {
            var i = 0;

            foreach (var beer in beers)
            {
                i++;

                //beer.BreweryName = "My Brewery " + i;
                beer.BeerName = "My Beer " + i;
            }
        }

        private static void Publish(FyneFestData data)
        {
            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AZURE_BLOB_STORAGE_CONNECTION_STRING"));
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("data-prod");

            CloudBlockBlob blob = container.GetBlockBlobReference("fynefest-1.0.0-dev.json");

            using (var ms = new MemoryStream())
            {
                var writer = new JsonTextWriter(new StreamWriter(ms));
                JsonSerializer.Create().Serialize(writer, data);
                writer.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                blob.UploadFromStream(ms);
            }
        }
    }
}
