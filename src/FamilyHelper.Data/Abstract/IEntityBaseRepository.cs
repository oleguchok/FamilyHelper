using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyHelper.Entities.Abstract;

namespace FamilyHelper.Data.Abstract
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

    }
}
