using FamilyHelper.Entities.Abstract;

namespace FamilyHelper.Entities.Entities
{
    public class Family : IEntityBase
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
    }
}
