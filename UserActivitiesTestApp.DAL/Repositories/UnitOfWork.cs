using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using UserActivitiesTestApp.Contractors.DAL;

namespace UserActivitiesTestApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private bool _disposed;
        private IActivityRepository _activityRepository;
        private IRandomUrlStorageRepository _randomUrlStorageRepository;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActivityRepository ActivityRepository => _activityRepository ?? (_activityRepository = new ActivityRepository(_applicationDbContext));

        public IRandomUrlStorageRepository RandomUrlStorageRepository => _randomUrlStorageRepository ?? (_randomUrlStorageRepository = new RandomUrlStorageRepository(_applicationDbContext));

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public int Save()
        {
            return _applicationDbContext.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDbContext?.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
