using BestCompany.Core.Entities;

namespace BestCompany.Business.Interfaces
{
    public interface IDepartmentService
    {
        void Create(string name, int maxEmpCount, int companyId);
        void Update(int id,string name,int maxEmpCount);
        void Delete(int id);
        void ShowAll();
        void GetDepartmentById(int id);
        void SearchDepartment(string name);
        Department? FindDepartmentById(int id);
        Department? FindDepartmentByName(string name);

        bool IsDepartmentExist();
    }
}
