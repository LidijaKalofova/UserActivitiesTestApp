using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserActivitiesTestApp.BO.Models;
using UserActivitiesTestApp.Contractors.DAL;
using UserActivitiesTestApp.Contractors.Logic;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.Logic.Managers
{
    public class RandomUrlStorageManager : ManagerBase, IRandomUrlStorageManager
    {
        public RandomUrlStorageManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public RandomUrlStorageViewModel GetSpecificUrl(string shortUrl)
        {
            return UnitOfWork.RandomUrlStorageRepository.GetSpecificUrl(shortUrl);
        }

        public async Task InsertRandomUrl(RandomUrlStorageViewModel randomUrlStorageViewModel)
        {
            await UnitOfWork.RandomUrlStorageRepository.InsertRandomUrl(randomUrlStorageViewModel);
        }
    }
}
