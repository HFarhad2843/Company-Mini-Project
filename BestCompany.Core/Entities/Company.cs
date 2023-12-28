using BestCompany.Core.Interfaces;

namespace BestCompany.Core.Entities
{
    public class Company : IEntity
    {
        public int Id { get; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
        private static int _id=1;

        public Company(string name)
        {
            Id = _id++;
            Name = name;
        }
    }
}
