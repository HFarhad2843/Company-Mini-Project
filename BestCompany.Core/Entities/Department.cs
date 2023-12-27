using BestCompany.Core.Interfaces;

namespace BestCompany.Core.Entities
{
    public class Department : IEntity
    {
        public int Id { get; }
        public string Name { get; set; }
        public int EmployeeLimit { get; set; }
        public int CurrentEmployeeCount { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public bool IsActive { get; set; } = true;
        private static int _id;
        public Department(string name,int employeeLimit,int companyId)
        {
            Id = _id++;
            Name = name;
           // Company = companyId;
            CompanyId = companyId;
            EmployeeLimit = employeeLimit;
            //Description = description;
        }
    }
}
