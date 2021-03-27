using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivitiesTestApp.BO.Models;
using UserActivitiesTestApp.Contractors.DAL;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.DAL.Repositories
{
    public class RandomUrlStorageRepository : Repository<RandomUrlStorage>, IRandomUrlStorageRepository
    {
        //protected ApplicationDbContext applicationDbContext;
        public RandomUrlStorageRepository(ApplicationDbContext _applicationDbContext)
            :base(_applicationDbContext)
        {
            
        }

        public RandomUrlStorageViewModel GetSpecificUrl(string shortUrl)
        {
            RandomUrlStorage randomUrlStorage = new RandomUrlStorage();
            RandomUrlStorageViewModel randomUrlStorageViewModel = new RandomUrlStorageViewModel();
            try
            {
                randomUrlStorage = _context.RandomUrlStorage.FirstOrDefault(r => r.ShortUrl == shortUrl);
                randomUrlStorageViewModel.Id = randomUrlStorage.Id;
                randomUrlStorageViewModel.SelectedDateFrom = randomUrlStorage.SelectedDateFrom;
                randomUrlStorageViewModel.SelectedDateTo = randomUrlStorage.SelectedDateTo;
                randomUrlStorageViewModel.UrlString = randomUrlStorage.UrlString;
                randomUrlStorageViewModel.ShortUrl = randomUrlStorage.ShortUrl;
                randomUrlStorageViewModel.UserId = randomUrlStorage.UserId;

                return randomUrlStorageViewModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        public async Task InsertRandomUrl(RandomUrlStorageViewModel randomUrlStorageViewModel)
        {
            try
            {
                RandomUrlStorage randomUrlStorage = new RandomUrlStorage();
                randomUrlStorage.UrlString = randomUrlStorageViewModel.UrlString;
                randomUrlStorage.ShortUrl = randomUrlStorageViewModel.ShortUrl;
                randomUrlStorage.UserId = randomUrlStorageViewModel.UserId;
                randomUrlStorage.SelectedDateFrom = randomUrlStorageViewModel.SelectedDateFrom;
                randomUrlStorage.SelectedDateTo = randomUrlStorageViewModel.SelectedDateTo;

                await InsertAsync(randomUrlStorage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
