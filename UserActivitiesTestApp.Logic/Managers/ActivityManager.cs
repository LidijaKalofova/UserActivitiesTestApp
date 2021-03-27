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
    public class ActivityManager : ManagerBase, IActivityManager
    {
        public ActivityManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public ICollection<Activity> GetActivitiesByDateRange(DateTime? dateFrom, DateTime? dateTo, string LoggedInUserId)
        {
            return UnitOfWork.ActivityRepository.GetActivitiesByDateRange(dateFrom, dateTo, LoggedInUserId);
        }

        public async Task<ICollection<Activity>> GetAllActivitiesByLoggedUserAsync(string LoggedInUserId)
        {
            return await UnitOfWork.ActivityRepository.GetAllActivitiesByLoggedUserAsync(LoggedInUserId);
        }

        public async Task InsertActivity(ActivityViewModel activityViewModel)
        {
            await UnitOfWork.ActivityRepository.InsertActivity(activityViewModel);
        }        
    }
}
