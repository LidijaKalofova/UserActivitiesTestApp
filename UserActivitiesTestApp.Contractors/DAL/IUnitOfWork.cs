using System;
using System.Collections.Generic;
using System.Text;

namespace UserActivitiesTestApp.Contractors.DAL
{
    public interface IUnitOfWork
    {
        IActivityRepository ActivityRepository { get; }
        IRandomUrlStorageRepository RandomUrlStorageRepository { get; }
        void Dispose();
        int Save();
    }
}
