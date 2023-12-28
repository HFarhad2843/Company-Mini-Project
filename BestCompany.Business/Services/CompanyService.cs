using BestCompany.Business.Interfaces;
using BestCompany.Business.Utilities.Exceptions;
using BestCompany.Core.Entities;
using BestCompany.DataAccess.Contexts;
using System.Xml.Linq;

namespace BestCompany.Business.Services
{
    public class CompanyService : ICompanyService
    {
        //private IGroupService _groupService { get; }
        //public CategoryService()
        //{
        //    _groupService = new GroupService();

        //}
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
        public void Activate(string name)
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
            GetCompanyDepartments(dbCompany.Name);
        }

        public void GetCompanyDepartments(string name)
        {
            foreach (var item in BestCompanyDbContext.Departments)
            {
                if (item.Company.Name.ToLower() == name.ToLower())
                {
                    if (item.IsActive == true)
                    {
                        Console.WriteLine($"Department Id: {item.Id}\n" +
                                          $"Department Name: {item.Name}\n");
                    }
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

        public void UpdateCompany(int companyId, string companyNewName)
        {
            if (String.IsNullOrEmpty(companyNewName)) throw new ArgumentNullException();

            Company? dbCompany =
                BestCompanyDbContext.Companies.Find(c => c.Id== companyId);
            if (dbCompany is null)
                throw new NotFoundException($"{companyId} company not found");
            dbCompany.Name = companyNewName;
        }
    }
}
