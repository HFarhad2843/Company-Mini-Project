using BestCompany.Business.Interfaces;
using BestCompany.Business.Utilities.Exceptions;
using BestCompany.Core.Entities;
using BestCompany.DataAccess.Contexts;
using System.Xml.Linq;

namespace BestCompany.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private ICompanyService companyService { get; }
        public DepartmentService()
        {
            companyService = new CompanyService();
        }
        public void Create(string name, int maxEmpCount, int companyId)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Department? dbDepartment =
                BestCompanyDbContext.Departments.Find(c => c.Name.ToLower() == name.ToLower());
            if (dbDepartment is not null)
                throw new AlreadyExistException($"{dbDepartment.Name} is already exist");
            if (maxEmpCount < 4)
                throw new MinCountException("Minimum employee count requirement is 4");
            Company? company = companyService.FindCompanyById(companyId);
            if (company is null) throw new NotFoundException($"{companyId} is not exist");
            Department department = new(name, maxEmpCount, company);
            BestCompanyDbContext.Departments.Add(department);
        }

        public Department? FindDepartmentById(int id)
        {
            return BestCompanyDbContext.Departments.Find(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var isDepartment = BestCompanyDbContext.Departments.Find(x => x.Id == id);
            if (isDepartment is null) throw new NotFoundException($"{id} kodlu departament tapilmadi");
            isDepartment.IsActive = false;
        }

        public void GetDepartmentById(int id)
        {
            Department? dbDepartment =
                BestCompanyDbContext.Departments.Find(c => c.Id == id);
            if (dbDepartment is null)
                throw new NotFoundException($"{id} kodlu departament tapılmadı");
            Console.WriteLine($"Department Id: {dbDepartment.Id}\n" +
                              $"Department Name: {dbDepartment.Name}\n" +
                              $"Department Employee Limit: {dbDepartment.Capacity}\n"+
                              $"Company Name: {dbDepartment.Company.Name}");
        }

        public void ShowAll()
        {
            foreach (var department in BestCompanyDbContext.Departments)
            {
                if (department.IsActive == true) Console.WriteLine($"Department Id: {department.Id}; Department name:{department.Name}; Company name:{department.Company.Name}; Capacity:{department.Capacity};Current Emp Count:{department.CurrentEmployeeCount}");
            }
        }

        public void GetDepartmentEmployee(string name)
        {
            foreach (var item in BestCompanyDbContext.Employees)
            {
                if (item.Department.Name.ToLower() == name.ToLower())
                {
                    if (item.IsActive == true)
                    {
                        Console.WriteLine($"Employee ID: {item.Id}\n" +
                                          $"Name: {item.Name}\n" +
                                          $"Surname: {item.SurName}\n" +
                                          $"Salary: {item.Salary}");
                    }
                }
            }
        }

        public bool IsDepartmentExist()
        {
            foreach (var item in BestCompanyDbContext.Departments)
            {
                if (item is not null && item.IsActive == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void Update(int id, string name, int capacity)
        {
            var isDepartment = BestCompanyDbContext.Departments.Find(x => x.Id == id);
            if (isDepartment is null) throw new NotFoundException($"{id} kodlu departament tapılmadı");
            isDepartment.Name = name;
            isDepartment.CurrentEmployeeCount = capacity;
        }

        public void SearchDepartment(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            var isDepartment = BestCompanyDbContext.Departments.Find(x => x.Name.ToLower() == name.ToLower());
            if (isDepartment is null) throw new NotFoundException($"{name} adlı departament tapılmadı");

            Console.WriteLine($"Department Id: {isDepartment.Id}; Department name:{isDepartment.Name};DepartmentCapacity: {isDepartment.Capacity}");
        }

        public Department? FindDepartmentByName(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            return BestCompanyDbContext.Departments.Find(g => g.Name.ToLower() == name.ToLower());
        }
    }
}
