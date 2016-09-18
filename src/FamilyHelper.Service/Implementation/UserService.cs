using System.Collections.Generic;
using FamilyHelper.Data.Infrastructure;
using FamilyHelper.Entities.Entities;
using FamilyHelper.Service.Abstract;

namespace FamilyHelper.Service.Implementation
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll();
        }
    }
}
