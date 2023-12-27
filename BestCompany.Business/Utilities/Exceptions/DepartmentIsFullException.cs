namespace BestCompany.Business.Utilities.Exceptions
{
    public class DepartmentIsFullException : Exception
    {
        public DepartmentIsFullException(string message) : base(message) { }

    }
}
