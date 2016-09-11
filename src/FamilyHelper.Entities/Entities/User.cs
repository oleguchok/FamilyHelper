using System;
using FamilyHelper.Entities.Abstract;

namespace FamilyHelper.Entities.Entities
{
    public class User : IEntityBase
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public long FamilyId { get; set; }
        public Family Family { get; set; }
    }
}
