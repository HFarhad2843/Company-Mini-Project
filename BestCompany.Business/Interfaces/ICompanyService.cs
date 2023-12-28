using BestCompany.Core.Entities;

namespace BestCompany.Business.Interfaces
{
    public interface ICompanyService
    {
        void Create(string name);
        void Delete(string name);
        void Activate(string? name);
        void ShowAll();
        void GetCompany(string name);
        Company? FindCompanyByName(string name);
        bool IsCompanyExist();
    }
}
