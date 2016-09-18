using System.Collections.Generic;
using FamilyHelper.Entities.Entities;

namespace FamilyHelper.Service.Abstract
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}
