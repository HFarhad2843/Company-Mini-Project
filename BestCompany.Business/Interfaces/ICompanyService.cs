using BestCompany.Core.Entities;

namespace BestCompany.Business.Interfaces
{
    public interface ICompanyService
    {
        void Create(string name);
        void UpdateCompany(int companyId,string companyNewName);
        void Delete(string name);
        void Activate(string name);
        void ShowAll();
        void GetCompany(string name);
        Company? FindCompanyByName(string name);
        void GetCompanyDepartments(string name);
        bool IsCompanyExist();
    }
}
