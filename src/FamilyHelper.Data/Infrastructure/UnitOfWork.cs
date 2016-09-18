using System;
using FamilyHelper.Data.Abstract;
using FamilyHelper.Data.Repositories;
using FamilyHelper.Entities.Entities;

namespace FamilyHelper.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FamilyHelperContext _dbContext;
        private IEntityBaseRepository<User> _userRepository;
        private IEntityBaseRepository<Family> _familyRepository;
        private bool _isDisposed;

        public UnitOfWork(FamilyHelperContext dbContext)
        {
            _dbContext = dbContext;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #region Repositories
        public IEntityBaseRepository<User> UserRepository => 
            _userRepository ?? (_userRepository = new EntityBaseRepository<User>(_dbContext));

        public IEntityBaseRepository<Family> FamilyRepository => 
            _familyRepository ?? (_familyRepository = new EntityBaseRepository<Family>(_dbContext));
        #endregion

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
