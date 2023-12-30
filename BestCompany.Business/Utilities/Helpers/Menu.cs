namespace BestCompany.Business.Utilities.Helpers
{
    public enum Menu
    {
        //Company
        CreateCompany=1,
        ShowAllCompany,
        DeleteCompany,
        GetCompanyById,
        GetCompanyDepartments,
        UpdateCompany,

        //Department
        CreateDepartment,
        ShowAllDepartment,
        DeleteDepartment,
        GetDepartmentEmployee,
        GetDepartmentById,
        UpdateDepartment,
        SearchDepartment,

        //Employee
        CreateEmployee,
        ShowAllEmployee,
        FindEmployeeByName,
        FindEmployeeById,
        UpdateEmployee,
        DeleteEmployee,
        SearchEmployee,
        MoveEmployee
    }
}
