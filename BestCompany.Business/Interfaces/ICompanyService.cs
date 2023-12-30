using BestCompany.Core.Entities;

namespace BestCompany.Business.Interfaces
{
    public interface ICompanyService
    {
        void Create(string name);
        void ShowAll();
        void Delete(int id);
        void GetCompanyDepartments(int id);
        void UpdateCompany(int companyId,string companyNewName);
        void GetCompanyById(int id);
        void GetCompanyByName(string name);
        Company? FindCompanyById(int id);
        Company? FindCompanyByName(string name); 
        bool IsCompanyExist();
    }
}
