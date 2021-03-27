using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserActivitiesTestApp.BO.Models;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.Contractors.DAL
{
    public interface IActivityRepository : IRepository<Activity>
    {
        Task InsertActivity(ActivityViewModel activityViewModel);
        Task<ICollection<Activity>> GetAllActivitiesByLoggedUserAsync(string LoggedInUserId);
        ICollection<Activity> GetActivitiesByDateRange(DateTime? dateFrom, DateTime? dateTo, string LoggedInUserId);
    }
}
