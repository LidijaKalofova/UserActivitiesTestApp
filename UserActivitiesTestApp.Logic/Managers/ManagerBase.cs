using System;
using System.Collections.Generic;
using System.Text;
using UserActivitiesTestApp.Contractors.DAL;

namespace UserActivitiesTestApp.Logic.Managers
{
    public abstract class ManagerBase
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public void Save()
        {
            UnitOfWork.Save();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
