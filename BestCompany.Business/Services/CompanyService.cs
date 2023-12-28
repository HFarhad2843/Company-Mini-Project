using BestCompany.Business.Interfaces;
using BestCompany.Business.Utilities.Exceptions;
using BestCompany.Core.Entities;
using BestCompany.DataAccess.Contexts;

namespace BestCompany.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private IGroupService _groupService { get; }
        public CategoryService()
        {
            _groupService = new GroupService();

        }
        public void Create(string? name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Company? dbCompany =
                BestCompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
            if (dbCompany is not null)
                throw new AlreadyExistException($"{dbCompany.Name} is already exist");
            Company company = new(name);
            BestCompanyDbContext.Companies.Add(company);
        }
        public void Activate(string? name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Company? dbCompany =
                BestCompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
            if (dbCompany is null)
                throw new NotFoundException($"{name} company not found");
            dbCompany.IsActive = true;
        }

        public void Delete(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Company? dbCompany =
                BestCompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
            if (dbCompany is null)
                throw new NotFoundException($"{name} company not found");
            dbCompany.IsActive = false;
        }

        public void GetCompany(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Company? dbCompany =
                BestCompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
            if (dbCompany is null)
                throw new NotFoundException($"{name} company not found");
            Console.WriteLine($"id: {dbCompany.Id}\n" +
                              $"Company Name: {dbCompany.Name}\n" +
                              $"Company Description: {dbCompany.Name}");
            GetGroupIncluded(dbCompany.Name);
        }

        public void GetGroupIncluded(string name)
        {
            foreach (var group in BestCompanyDbContext.Companies)
            {
                if (group.Category.Name.ToLower() == name.ToLower())
                {
                    Console.WriteLine($"Id: {group.Id}; Group name:{group.Name}");
                    Console.WriteLine("------------------------------------------");
                }
            }
        }

        public void ShowAll()
        {
            foreach (var company in BestCompanyDbContext.Companies)
            {
                if (company.IsActive == true)
                {
                    Console.WriteLine($"id: {company.Id}; Company Name: {company.Name}");
                }
            }
        }

        public Company? FindCompanyByName(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            return BestCompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        }

        public bool IsCompanyExist()
        {
            foreach (var item in BestCompanyDbContext.Companies)
            {
                if (item is not null && item.IsActive == true) return true;
            }
            return false;
        }
    }
}
