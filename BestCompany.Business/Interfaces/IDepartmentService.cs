using BestCompany.Core.Entities;

namespace BestCompany.Business.Interfaces
{
    public interface IDepartmentService
    {
    //    void Create(string? name, string? description);
        void Delete(string name);
        void Activate(string name);
        void ShowAll();
      //  void GetDepartment(string name);
      //  Department? FindDepartmentByName(string name);
        bool IsDepartmentExist();
    }
}
