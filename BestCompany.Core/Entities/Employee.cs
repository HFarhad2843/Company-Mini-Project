using BestCompany.Core.Interfaces;

namespace BestCompany.Core.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; }
        public decimal Salary { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsActive { get; set; } = false;
        private static int _id;
        public Employee(string name,string surname,decimal salary,int departmentId)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || salary <= 0)
            {
                throw new ArgumentException("Name, surname, and salary are required.");
            }

            Id = _id++;
            Name = name;
            SurName = surname;
            Salary = salary;
            DepartmentId = departmentId;
        }
        public override string ToString()
        {
            return $"{Id},{Name},{SurName}";
        }
        public static Employee Create(string name, string surname, decimal salary, int departmentId)
        {
            return new Employee(name, surname, salary, departmentId);
        }

    }
}
