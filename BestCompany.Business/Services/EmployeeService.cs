using BestCompany.Business.Interfaces;
using BestCompany.Business.Utilities.Exceptions;
using BestCompany.Core.Entities;
using BestCompany.DataAccess.Contexts;

namespace BestCompany.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IDepartmentService departmentService { get; }
        public EmployeeService()
        {
            departmentService = new DepartmentService();
        }
        public void Create(string name, string surname, decimal salary, string departmentName)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Department? department = departmentService.FindDepartmentByName(departmentName,);
            if (department is null) throw new NotFoundException($"{departmentName} is not exist");
            if (department.EmployeeLimit == department.CurrentEmployeeCount)
            {
                throw new DepartmentIsFullException($"{department.Name} is already full");
            }
            Employee employee = new(name, surname, salary, department.Id);
            BestCompanyDbContext.Employees.Add(employee);
            department.CurrentEmployeeCount++;
        }


        public void Delete(int Id)
        {
            var employee = BestCompanyDbContext.Employees.Find(x => x.Id == Id);
            if (employee is null) throw new NotFoundException("employee Not Found");
            employee.IsActive = false;
            if (employee.Department.CurrentEmployeeCount > 4)
            {
                employee.Department.CurrentEmployeeCount--;
            }
                  else groupService.Delete(student.Group.Name);
        }

        public void ShowAll()
        {
            foreach (var item in BestCompanyDbContext.Employees)
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
}
