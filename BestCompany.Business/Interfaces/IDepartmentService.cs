using BestCompany.Core.Entities;

namespace BestCompany.Business.Interfaces
{
    public interface IDepartmentService
    {
        void Create(string name, int maxEmpCount, string companyName);
        void Update(int id,string name,int maxEmpCount);
        void Delete(string name);
        void Activate(string name);
        void ShowAll();
        void GetDepartmentById(int id);
        bool IsDepartmentExist();
    }
}
