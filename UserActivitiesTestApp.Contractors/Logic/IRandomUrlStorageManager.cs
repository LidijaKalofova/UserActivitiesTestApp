using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserActivitiesTestApp.BO.Models;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.Contractors.Logic
{
    public interface IRandomUrlStorageManager
    {
        RandomUrlStorageViewModel GetSpecificUrl(string shortUrl);
        Task InsertRandomUrl(RandomUrlStorageViewModel randomUrlStorageViewModel);
    }
}
