using FamilyHelper.Data.Abstract;
using FamilyHelper.Entities.Entities;

namespace FamilyHelper.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IEntityBaseRepository<User> UserRepository { get; }
        void Commit();
    }
}
