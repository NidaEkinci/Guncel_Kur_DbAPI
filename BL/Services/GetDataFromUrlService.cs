using DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Xml.Linq;

namespace BL.Services
{
    public class GetDataFromUrlService : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        public GetDataFromUrlService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            GetDataFromUrlAsync();
        }
        public async Task GetDataFromUrlAsync()
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetRequiredService<DataService>();

                string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
                var client = new HttpClient();
                var response = await client.GetStringAsync(url);
                XDocument xmlDoc = XDocument.Parse(response);

                var currencies = xmlDoc.Descendants("Currency")
                    .Select(element => new Currency
                    {
                        DovizKodu = element.Attribute("CurrencyCode")?.Value,
                        Birim = element.Element("Unit")?.Value,
                        DovizCinsi = element.Element("Isim")?.Value,
                        DovizAdi = element.Element("CurrencyName")?.Value,
                        DovizAlis = element.Element("ForexBuying")?.Value,
                        DovizSatis = element.Element("ForexSelling")?.Value,
                        EfektifAlis = element.Element("BanknoteBuying")?.Value,
                        EfektifSatis = element.Element("BanknoteSelling")?.Value
                    })
                    .ToList();

                await dataService.CreateDataAsync(currencies);
            }            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }
    }
}
