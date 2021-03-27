using System;
using System.Collections.Generic;
using System.Text;
using UserActivitiesTestApp.Contractors.DAL;

namespace UserActivitiesTestApp.Contractors.Logic
{
    public interface ILogicManager
    {
        IUnitOfWork UnitOfWork { get; set; }
        IActivityManager ActivityManager { get; set; }
        IRandomUrlStorageManager RandomUrlStorageManager { get; set; }
    }
}
