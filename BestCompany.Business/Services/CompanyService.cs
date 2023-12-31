﻿using BestCompany.Business.Interfaces;
using BestCompany.Business.Utilities.Exceptions;
using BestCompany.Core.Entities;
using BestCompany.DataAccess.Contexts;

namespace BestCompany.Business.Services
{
    public class CompanyService : ICompanyService
    {

        public void Create(string? name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Company? dbCompany =
                BestCompanyDbContext.Companies.Where(x=>x.IsActive==true && x.Name.ToLower()==name.ToLower()).FirstOrDefault();
            if (dbCompany is not null)
                throw new AlreadyExistException($"{dbCompany.Name} is already exist");
            Company company = new(name);
            BestCompanyDbContext.Companies.Add(company);
        }
        public void Delete(int id)
        {
            Company? dbCompany =
                BestCompanyDbContext.Companies.Find(c => c.Id == id);
            if (dbCompany is null)
                throw new NotFoundException($"{id} kodlu company not found");
            dbCompany.IsActive = false;
        }

        public void GetCompanyByName(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Company? dbCompany =
                BestCompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
            if (dbCompany is null)
                throw new NotFoundException($"{name} company not found");
            Console.WriteLine($"Company Id: {dbCompany.Id}\n" +
                              $"Company Name: {dbCompany.Name}\n");
            GetCompanyDepartments(dbCompany.Id);
        }
        public void GetCompanyById(int id)
        {
            Company? dbCompany =
                BestCompanyDbContext.Companies.Find(c => c.Id==id);
            if (dbCompany is null)
                throw new NotFoundException($"{id} company not found");
            Console.WriteLine($"Company Id: {dbCompany.Id}\n" +
                              $"Company Name: {dbCompany.Name}\n");
            GetCompanyDepartments(dbCompany.Id);
        }

        public void GetCompanyDepartments(int id)
        {
            foreach (var item in BestCompanyDbContext.Departments)
            {
                if (item.Company.Id == id)
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
        public Company? FindCompanyById(int id)
        {
            return BestCompanyDbContext.Companies.Find(c => c.Id == id);
        }
        public Company? FindCompanyByName(string name)
        {
            return BestCompanyDbContext.Companies.Find(c => c.Name == name);
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
                BestCompanyDbContext.Companies.Find(c => c.Id == companyId);
            if (dbCompany is null)
                throw new NotFoundException($"{companyId} company not found");
            dbCompany.Name = companyNewName;
        } 
    }
}
