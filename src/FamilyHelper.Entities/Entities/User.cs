using System;
using FamilyHelper.Entities.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FamilyHelper.Entities.Entities
{
    public class User : IdentityUser<long>, IEntityBase
    {
        public override long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public long FamilyId { get; set; }
        public Family Family { get; set; }
    }
}
