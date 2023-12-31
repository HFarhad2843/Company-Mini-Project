using BestCompany.Core.Entities;

namespace BestCompany.Business.Interfaces
{
    public interface IEmployeeService
    {
        void Create(string name, string surname, decimal salary, int department_id, int Age, string Address);
        void Delete(int id);
        void Update(int id, string name, string surname, decimal salary,  int Age, string Address);
        void ShowAll();
        void GetEmployeeByName(string name);
        void SearchEmployee(string? name,string? surname);

        void GetEmployeeById(int id);
        Employee? FindEmployeeById(int id);
        public void ChangeDepartment(int empId, int DepartmentId);

    }
}
