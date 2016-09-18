using System;
using FamilyHelper.Data.Abstract;
using FamilyHelper.Data.Repositories;
using FamilyHelper.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyHelper.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext;
        private bool _isDisposed;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public IEntityBaseRepository<User> UserRepository => new EntityBaseRepository<User>(_dbContext);

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                _dbContext.Dispose();
            }

            _isDisposed = true;
        }
    }
}
