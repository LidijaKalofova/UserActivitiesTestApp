using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserActivitiesTestApp.BO.Models;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.Contractors.DAL
{
    public interface IRandomUrlStorageRepository
    {
        RandomUrlStorageViewModel GetSpecificUrl(string shortUrl);
        Task InsertRandomUrl(RandomUrlStorageViewModel randomUrlStorageViewModel);
    }
}
