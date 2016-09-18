using System.Collections.Generic;
using System.Linq;
using FamilyHelper.Data.Abstract;
using FamilyHelper.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FamilyHelper.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        private readonly DbContext _context;

        public EntityBaseRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetSingle(int id)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id == id);
        }
    }
}
