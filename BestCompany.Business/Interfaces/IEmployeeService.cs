using BestCompany.Core.Entities;

namespace BestCompany.Business.Interfaces
{
    public interface IEmployeeService
    {
        void Create(string name, string surname,decimal? salary,string department_name);
        void Delete(int id);
     //   void Activate(string name);
        void ShowAll();
        //void GetEmployee(string name);
       // Employee? FindEmployeeByName(string name);
      //  bool IsDepartmentExist();
    }
}
