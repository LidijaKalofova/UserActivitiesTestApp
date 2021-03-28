using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UserActivitiesTestApp.BO.Models;
using UserActivitiesTestApp.Contractors.Logic;
using UserActivitiesTestApp.Domain.Entities;
using UserActivitiesTestApp.Models;

namespace UserActivitiesTestApp.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly ILogicManager _logicManager;
        private readonly UserManager<User> _userManager;

        public ActivityController(ILogicManager logicManager,
            UserManager<User> userManager)
        {
            _logicManager = logicManager;
            _userManager = userManager;
        }

        //Shows Activity View
        public IActionResult Activity()
        {
            return View("Activity");
        }

        //Shows Add Activity View
        public IActionResult AddActivity()
        {
            return View("AddActivity");
        }

        //Shows Error View with the exception
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View("Error", errorViewModel);
        }

        //Adds activity by current logged in user and calculates time spent on that activity
        [HttpPost]
        public async Task<IActionResult> AddActivity(ActivityViewModel activityViewModel)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    activityViewModel.Id = Guid.NewGuid();
                    var timeDiff = activityViewModel.ActivityEnd.Subtract(activityViewModel.ActivityStart);
                    activityViewModel.ActivityTimeSpent = timeDiff.Ticks;
                    activityViewModel.TimeSpent = string.Format("{0} years {1} months {2} days {3} hours {4} minutes {5} seconds",
                                                        (int)timeDiff.TotalDays / 365,
                                                        (int)(timeDiff.TotalDays % 365) / 30,
                                                        timeDiff.Days % 30,
                                                        timeDiff.Hours,
                                                        timeDiff.Minutes,
                                                        timeDiff.Seconds);
                    activityViewModel.UserId = GetCurrentUserId().Result;

                    await _logicManager.ActivityManager.InsertActivity(activityViewModel);
                }

                return View("AddActivity", activityViewModel);
            }
            catch(Exception ex)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ErrorMessage = ex.Message;
                return RedirectToAction("Error", errorViewModel);
            }
            
        }

        //Activity Report loads table with Activities by logged in user
        [HttpGet("/Activity/ActivityReport/")]
        public async Task<IActionResult> GetActivityReport()
        {
            string LoggedInUserId = GetCurrentUserId().Result;
            ActivityReportViewModel activityReportViewModel = new ActivityReportViewModel();

            activityReportViewModel.ActivityList = await _logicManager.ActivityManager.GetAllActivitiesByLoggedUserAsync(LoggedInUserId);

            return View("ActivityReport", activityReportViewModel);
        }

        //Print Report displays every day in selected interval and
        //total time spent on the activities in that interval for logged user
        [HttpGet("/Activity/PrintReport/")]
        public async Task<IActionResult> GetPrintReport()
        {
            string LoggedInUserId = GetCurrentUserId().Result;
            ActivityReportViewModel activityReportViewModel = new ActivityReportViewModel();

            activityReportViewModel.ActivityList = await _logicManager.ActivityManager.GetAllActivitiesByLoggedUserAsync(LoggedInUserId);

            return View("PrintReport", activityReportViewModel);
        }

        //Logic for displaying activities by date range for Activity report
        [HttpPost]
        public IActionResult ActivitiesByDateRange(ActivityReportViewModel activityReportViewModel)
        {
            string LoggedInUserId = GetCurrentUserId().Result;
            if (activityReportViewModel.DateFrom != null && activityReportViewModel.DateTo != null)
            {
                activityReportViewModel.ActivityList = _logicManager.ActivityManager.GetActivitiesByDateRange(activityReportViewModel.DateFrom,
                                                                                                              activityReportViewModel.DateTo,
                                                                                                              LoggedInUserId).ToList();
            }

            return View("ActivityReport", activityReportViewModel);
        }

        //Logic for displaying activities by date range for Print report
        [HttpPost]
        public IActionResult PrintActivitiesByDateRange(ActivityReportViewModel activityReportViewModel)
        {
            List<TimeSpan> TimeSpentList = new List<TimeSpan>();
            string LoggedInUserId = GetCurrentUserId().Result;
            activityReportViewModel.ActivityList = _logicManager.ActivityManager.GetActivitiesByDateRange(activityReportViewModel.DateFrom,
                                                                                                          activityReportViewModel.DateTo,
                                                                                                          LoggedInUserId).ToList();

            foreach (var item in activityReportViewModel.ActivityList)
            {
                TimeSpan ts = TimeSpan.FromTicks(item.ActivityTimeSpent);
                TimeSpentList.Add(ts);
            }

            var totalTimeSpent = new TimeSpan(TimeSpentList.Sum(r => r.Ticks));
            activityReportViewModel.TotalTimeSpent = string.Format("{0} years {1} months {2} days {3} hours {4} minutes {5} seconds",
                                                    (int)totalTimeSpent.TotalDays / 365,
                                                    (int)(totalTimeSpent.TotalDays % 365) / 30,
                                                    totalTimeSpent.Days % 30,
                                                    totalTimeSpent.Hours,
                                                    totalTimeSpent.Minutes,
                                                    totalTimeSpent.Seconds);

            return View("PrintReport", activityReportViewModel);
        }

        //Logic for sending the displayed Activity report within range to email
        //Generates unique link that alows the Email Recipient to view the Report without to have to log in the system
        public async Task<IActionResult> SendEmail(ActivityReportViewModel activityReportViewModel)
        {
            try
            {
                RandomUrlStorageViewModel randomUrlStorageViewModel = new RandomUrlStorageViewModel();
                randomUrlStorageViewModel.UserId = GetCurrentUserId().Result;
                randomUrlStorageViewModel.ShortUrl = Guid.NewGuid().ToString();
                randomUrlStorageViewModel.UrlString = "https://useractivitiestestapp20210327105841.azurewebsites.net/UserActivityReport/UserActivityReport/" + randomUrlStorageViewModel.ShortUrl;
                randomUrlStorageViewModel.SelectedDateFrom = activityReportViewModel.DateFrom;
                randomUrlStorageViewModel.SelectedDateTo = activityReportViewModel.DateTo;
                await _logicManager.RandomUrlStorageManager.InsertRandomUrl(randomUrlStorageViewModel);

                // Credentials
                var credentials = new NetworkCredential(activityReportViewModel.EmailViewModel.SenderEmail, activityReportViewModel.EmailViewModel.SenderPassword);
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(activityReportViewModel.EmailViewModel.SenderEmail),
                    Subject = "User Activity Report",
                    Body = randomUrlStorageViewModel.UrlString
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(activityReportViewModel.EmailViewModel.EmailReceiver));
                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
                return RedirectToAction("ActivityReport");
            }
            catch (Exception ex)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.ErrorMessage = ex.Message;
                return RedirectToAction("Error", errorViewModel);
            }

        }

        //Gets current logged in user id
        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            User usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        //Gets current logged in user
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
