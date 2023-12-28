using BestCompany.Core.Interfaces;

namespace BestCompany.Core.Entities
{
    public class Department : IEntity
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int CurrentEmployeeCount { get; set; }
        public Company Company { get; set; }
        public bool IsActive { get; set; } = false;
        private static int _id=1;
        public Department(string name,int capacity, Company company)
        {
            Id = _id++;
            Name = name;
            Company = company;
            Capacity = capacity;
        }
    }
}
