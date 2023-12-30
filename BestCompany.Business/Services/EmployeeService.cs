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
        public void Create(string name, string surname, decimal salary, int departmentId, int Age, string Address)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Department? department = departmentService.FindDepartmentById(departmentId);
            if (department is null) throw new NotFoundException($"{departmentId} is not exist");
            if (department.Capacity == department.CurrentEmployeeCount)
            {
                throw new DepartmentIsFullException($"{department.Name} is already full");
            }
            Employee employee = new(name, surname, salary, department, Age, Address);
            BestCompanyDbContext.Employees.Add(employee);
            department.CurrentEmployeeCount++;
        }


        public void Delete(int Id)
        {
            var employee = BestCompanyDbContext.Employees.Find(x => x.Id == Id);
            if (employee is null) throw new NotFoundException("employee Not Found");
            employee.IsActive = false; 
                employee.Department.CurrentEmployeeCount--; 
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
                                     $"Department: {item.Department.Name}\n" +
                                     $"Salary: {item.Salary}");
                }
            }
        }

    

        public void GetEmployeeByName(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Employee? dbEmployee =
                                  BestCompanyDbContext.Employees.Find(c => c.Name.ToLower() == name.ToLower());
            if (dbEmployee is null)
                throw new NotFoundException($"{name} adlı işçi tapılmadı");
            Console.WriteLine($"Employee Id: {dbEmployee.Id}\n" +
                             $"Employee Name: {dbEmployee.Name}\n" +
                             $"Employee SurName: {dbEmployee.SurName}\n+" +
                             $"Employee Address: {dbEmployee.Address}\n+" +
                             $"Employee Age: {dbEmployee.Age}\n+" +
                             $"Employee Department: {dbEmployee.Department.Name}\n+");
        }

        public void GetEmployeeById(int id)
        {
            Employee? dbEmployee =
                        BestCompanyDbContext.Employees.Find(c => c.Id == id);
            if (dbEmployee is null)
                throw new NotFoundException($"{id} kodlu işçi tapılmadı");
            Console.WriteLine($"Employee Id: {dbEmployee.Id}\n" +
                             $"Employee Name: {dbEmployee.Name}\n" +
                             $"Employee SurName: {dbEmployee.SurName}\n+" +
                             $"Employee Address: {dbEmployee.Address}\n+" +
                             $"Employee Age: {dbEmployee.Age}\n+" +
                             $"Employee Department: {dbEmployee.Department.Name}\n+");
        }

        public Employee? FindEmployeeById(int id)
        {
            return BestCompanyDbContext.Employees.Find(g => g.Id == id);
        }

        public void Update(int id, string name, string surname, decimal salary, int Age, string Address)
        {
            var employee = BestCompanyDbContext.Employees.Find(x => x.Id == id);
            if (employee is null) throw new NotFoundException("employee Not Found");
            employee.Name = name;
            employee.SurName = surname;
            employee.Salary = salary;
            employee.Age = Age;
            employee.Address = Address;

            Console.WriteLine("Employee Update Successfull");
        }

        public void ChangeDepartment(int empId,int DepartmentId)
        {
            var employee = BestCompanyDbContext.Employees.Find(x => x.Id == empId);
           
            if (employee is null) throw new NotFoundException("employee Not Found");
            employee.Department.CurrentEmployeeCount--;

            var department = BestCompanyDbContext.Departments.Find(x => x.Id == DepartmentId);
            if (employee is null) throw new NotFoundException("employee Not Found");
            employee.DepartmentId = department.Id;
            employee.Department = department;
            employee.Department.CurrentEmployeeCount++;

            Console.WriteLine("Employee Moved Successfull");
        }
    }
}

// last upload
