using System.Collections;
using System.Collections.Generic;
using FamilyHelper.Entities.Abstract;

namespace FamilyHelper.Data.Abstract
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
    }
}
