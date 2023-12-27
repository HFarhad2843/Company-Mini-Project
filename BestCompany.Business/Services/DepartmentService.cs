using BestCompany.Business.Interfaces;
using BestCompany.Business.Utilities.Exceptions;
using BestCompany.Core.Entities;
using BestCompany.DataAccess.Contexts;

namespace BestCompany.Business.Services
{
    public class DepartmentService:IDepartmentService
    {
        private ICompanyService companyService { get; }
        public DepartmentService()
        {
            companyService = new CompanyService();
        }
        public void Create(string name, int maxEmpCount, string companyName)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Department? dbDepartment =
                BestCompanyDbContext.Departments.Find(c => c.Name.ToLower() == name.ToLower());
            if (dbDepartment is not null)
                throw new AlreadyExistException($"{dbDepartment.Name} is already exist");
            if (maxEmpCount < 4)
                throw new MinCountException("Minimum employee count requirement is 4");
            Company? company = companyService.FindCompanyByName(companyName);
            if (company is null) throw new NotFoundException($"{companyName} is not exist");
            Department department = new(name, maxEmpCount, company.Id);
            BestCompanyDbContext.Departments.Add(department);
        }
        public void Activate(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            var isDepartment = BestCompanyDbContext.Departments.Find(x => x.Name.ToLower() == name.ToLower());
            if (isDepartment is null) throw new NotFoundException($"{name} not found department");
            isDepartment.IsActive = true;
        }

        public void Delete(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            var isGroup = BestCompanyDbContext.Departments.Find(x => x.Name.ToLower() == name.ToLower());
            if (isGroup is null) throw new NotFoundException($"{name} not found department");
            isGroup.IsActive = false;
        }

        public Department? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Department? GetByName(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            return BestCompanyDbContext.Departments.Find(g => g.Name.ToLower() == name.ToLower());
        }

        public void ShowAll()
        {
            foreach (var department in BestCompanyDbContext.Departments)
            {
                if (department.IsActive == true) Console.WriteLine($"Id: {department.Id}; Department name:{department.Name}");
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
                        Console.WriteLine($"ID: {item.Id}\n" +
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

    }
}
