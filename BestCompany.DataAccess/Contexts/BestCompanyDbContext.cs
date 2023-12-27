using BestCompany.Core.Entities;

namespace BestCompany.DataAccess.Contexts
{
    public static class BestCompanyDbContext
    {
        public static List<Company> Companies { get; set; } = new List<Company>();
        public static List<Department> Departments { get; set; } = new List<Department>();
        public static List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
