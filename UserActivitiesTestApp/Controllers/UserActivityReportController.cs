using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserActivitiesTestApp.BO.Models;
using UserActivitiesTestApp.Contractors.Logic;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.Controllers
{
    public class UserActivityReportController : Controller
    {
        private readonly ILogicManager _logicManager;
        public string LoggedInUserId;
        public UserActivityReportController(ILogicManager logicManager)
        {
            _logicManager = logicManager;
        }

        //Displays Activity report that was sent trough email
        [HttpGet("/UserActivityReport/UserActivityReport/{shorturl}")]
        public IActionResult RedirectGeneratedUrl(string shorturl)
        {
            ActivityReportViewModel activityReportViewModel = new ActivityReportViewModel();

            activityReportViewModel.RandomUrlStorageViewModel = _logicManager.RandomUrlStorageManager.GetSpecificUrl(shorturl);
            LoggedInUserId = activityReportViewModel.RandomUrlStorageViewModel.UserId;
            
            if(activityReportViewModel.RandomUrlStorageViewModel.SelectedDateFrom != null && activityReportViewModel.RandomUrlStorageViewModel.SelectedDateTo != null)
            {
                activityReportViewModel.ActivityList = _logicManager.ActivityManager.GetActivitiesByDateRange(activityReportViewModel.RandomUrlStorageViewModel.SelectedDateFrom,
                                                                                                              activityReportViewModel.RandomUrlStorageViewModel.SelectedDateTo,
                                                                                                              LoggedInUserId).ToList();
            }
            else
            {
                activityReportViewModel.ActivityList = _logicManager.ActivityManager.GetAllActivitiesByLoggedUserAsync(LoggedInUserId).Result;
            }
            
            return View("UserActivityReport", activityReportViewModel);
        }

    }
}
