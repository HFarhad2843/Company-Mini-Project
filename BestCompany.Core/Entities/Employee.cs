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
        public bool IsActive { get; set; } = true;
        public int Age { get; set; }
        public string Address { get; set; }
        private static int _id=1;
        public Employee(string name,string surname, decimal salary, Department department, int age, string address)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || salary <= 0)
            {
                throw new ArgumentException("Name, surname, and salary are required.");
            }

            Id = _id++;
            Name = name;
            SurName = surname;
            Salary = salary;
            Department = department;
            DepartmentId = department.Id;
            Age = age;
            Address = address;
        }
        public override string ToString()
        {
            return $"{Id},{Name},{SurName}";
        }
    }
}
