using DAL.DbContexts;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class DataService
    {
        private readonly DataContext dataContext;

        public DataService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task CreateDataAsync(List<Currency> currencies)
        {
            dataContext.Currencies.AddRange(currencies);
            await dataContext.SaveChangesAsync();
        }
    }
}
