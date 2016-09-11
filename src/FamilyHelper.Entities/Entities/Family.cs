using System.Collections.Generic;
using FamilyHelper.Entities.Abstract;

namespace FamilyHelper.Entities.Entities
{
    public class Family : IEntityBase
    {
        public long Id { get; set; }
        public string FamilyName { get; set; }

        public List<User> Users { get; set; }
    }
}
