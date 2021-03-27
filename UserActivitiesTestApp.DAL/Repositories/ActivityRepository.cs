using Microsoft.EntityFrameworkCore;
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
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        protected ApplicationDbContext applicationDbContext;
        public ActivityRepository(ApplicationDbContext _applicationDbContext) 
            : base(_applicationDbContext)
        {
        }

        public ICollection<Activity> GetActivitiesByDateRange(DateTime? dateFrom, DateTime? dateTo, string LoggedInUserId)
        {
            return _context.Activity.Where(x => x.UserId == LoggedInUserId && x.ActivityStart >= dateFrom && x.ActivityStart < dateTo).ToList();
        }

        public async Task<ICollection<Activity>> GetAllActivitiesByLoggedUserAsync(string LoggedInUserId)
        {
            return await _context.Activity.Where(x => x.UserId == LoggedInUserId).ToListAsync();
        }

        public async Task InsertActivity(ActivityViewModel activityViewModel)
        {
            try
            {
                Activity activity = new Activity();
                activity.Id = activityViewModel.Id;
                activity.ActivityName = activityViewModel.ActivityName;
                activity.ActivityStart = activityViewModel.ActivityStart.Date;
                activity.ActivityEnd = activityViewModel.ActivityEnd.Date;
                activity.Description = activityViewModel.Description;
                activity.TimeSpent = activityViewModel.TimeSpent;
                activity.UserId = activityViewModel.UserId;
                activity.ActivityTimeSpent = activityViewModel.ActivityTimeSpent;
                await InsertAsync(activity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
