using System;
using System.Collections.Generic;
using System.Text;
using UserActivitiesTestApp.Contractors.DAL;
using UserActivitiesTestApp.Contractors.Logic;

namespace UserActivitiesTestApp.Logic.Managers
{
    public class LogicManager : ILogicManager
    {
        public IActivityManager _activityManager;
        public IRandomUrlStorageManager _randomUrlStorageManager;
        public LogicManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; set; }
        public IActivityManager ActivityManager 
        {
            get => _activityManager ?? (_activityManager = new ActivityManager(UnitOfWork));
            set => _activityManager = value;
        }
        public IRandomUrlStorageManager RandomUrlStorageManager 
        {
            get => _randomUrlStorageManager ?? (_randomUrlStorageManager = new RandomUrlStorageManager(UnitOfWork));
            set => _randomUrlStorageManager = value;
        }
    }
}
