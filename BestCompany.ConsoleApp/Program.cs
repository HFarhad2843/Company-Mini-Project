using BestCompany.Business.Services;
using BestCompany.Business.Utilities.Helpers;

Console.WriteLine("Welcome Company App");
Console.WriteLine();
Console.WriteLine("Company App Start:");
Console.WriteLine();
CompanyService companyService = new();
DepartmentService departmentService = new();
EmployeeService employeeService = new();
bool isContinue = true;
while (isContinue)
{
                      Console.WriteLine("Choose the option:");
                      Console.WriteLine("-- Company--\n" +
                      "1 - Create  Company \n" +
                      "2 - Show All Companies \n" +
                      "3 - Delete Company \n" +
                      "4 - Get Company By Id \n" +
                      "5 - Get Company Departments\n" +
                      "6 - Update Company Name\n");

                      Console.WriteLine("-- Department--\n" +
                      "7 - Create Department \n" +
                      "8 - Show All Department \n" +
                      "9 - Delete Department \n" +
                      "10 - Get Deparment Employees \n" +
                      "11 - Get Deparment By Id \n" +
                      "12 - Update Department \n"+
                      "13 - Search Department\n");

                      Console.WriteLine("-- Employees--\n" +
                      "14 - Create Employee \n" +
                      "15 - Show All Employee \n"+
                      "16 - FindEmployeeByName \n" +
                      "17 - FindEmployeeByID \n" +
                      "18 - UpdateEmployee \n" +
                      "19 - DeleteEmployee \n" +
                      "20 - SearchEmployee \n" +
                      "21 - MoveEmployee \n");

    string? option = Console.ReadLine();
    const int MaxMenu = 21;
    int optionNumber;
    bool isInt = int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if (optionNumber >= 0 && optionNumber <= MaxMenu)
        {
            switch (optionNumber)
            {
                case (int)Menu.CreateCompany:
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.Create(companyName);
                        Console.WriteLine("Company Yaradildi");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.CreateCompany;
                    }
                    break;
                case (int)Menu.ShowAllCompany:

                    Console.WriteLine("All Company:");
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.WriteLine("Company yoxdur:");
                    }
                    companyService.ShowAll();
                    break;
                case (int)Menu.DeleteCompany:
                    if (companyService.IsCompanyExist() == false) Console.WriteLine("Company yoxdur:");
                    try
                    {
                        Console.WriteLine("Enter Company Id:");
                        int companyId = Convert.ToInt32(Console.ReadLine());
                        companyService.Delete(companyId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.GetCompanyById:
                    if (companyService.IsCompanyExist() == false) Console.WriteLine("Company yoxdur:");
                    try
                    {
                        Console.WriteLine("Enter Company Id:");
                        int companyId = Convert.ToInt32(Console.ReadLine());
                        companyService.GetCompanyById(companyId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.GetCompanyDepartments:
                    try
                    {
                        Console.WriteLine("Enter Company Id:");
                        int companyId = Convert.ToInt32(Console.ReadLine());
                        companyService.GetCompanyDepartments(companyId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.UpdateCompany:
                    try
                    {
                        Console.WriteLine("Enter Company Id:");
                        int companyId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter  Company  New Name:");
                        string? companyNewName = Console.ReadLine();
                        companyService.UpdateCompany(companyId,companyNewName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                //----------------------Company Menu Finish------------------------




                case (int)Menu.CreateDepartment:
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.WriteLine("Company yoxdur ilk öncə company yaratmaq lazimdir:");
                        goto case (int)Menu.CreateCompany;
                    }
                    try
                    {
                        Console.WriteLine("Enter deparment name:");
                        string? departmentName = Console.ReadLine();
                        Console.WriteLine("Enter max Employee count:");
                        int maxEmpCount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("----------------------");
                        companyService.ShowAll();
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Enter company id:");
                        int companyId = Convert.ToInt32(Console.ReadLine());
                        departmentService.Create(departmentName, maxEmpCount, companyId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 3;
                    }
                    break;
                case (int)Menu.ShowAllDepartment:
                    if (departmentService.IsDepartmentExist() == false)
                    {
                        Console.WriteLine("Department Yoxdur");
                        goto case (int)Menu.CreateDepartment;
                    }
                    Console.WriteLine("All Department:");
                    departmentService.ShowAll();
                    break;

                case (int)Menu.DeleteDepartment:
                    try
                    {
                        Console.WriteLine("Enter department id:");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        departmentService.Delete(departmentId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.GetDepartmentEmployee:
                    try
                    {
                        Console.WriteLine("Enter department name:");
                        string? departmentName = Console.ReadLine();
                        departmentService.GetDepartmentEmployee(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                    case (int)Menu.GetDepartmentById:
                    try
                    {
                        Console.WriteLine("Enter Department Id:");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        departmentService.GetDepartmentById(departmentId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.UpdateDepartment:
                    try
                    {
                        Console.WriteLine("Enter Department Id:");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter New Department Name");
                        string departmentName = Console.ReadLine();
                        Console.WriteLine("Enter Department Capacity:");
                        int capacity = Convert.ToInt32(Console.ReadLine());
                        departmentService.Update(departmentId,departmentName,capacity);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.SearchDepartment:
                    try
                    {
                        Console.WriteLine("Enter Department Name:");
                        string departmentName = Console.ReadLine();
                        departmentService.SearchDepartment(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                //----------------------Department Menu Finish------------------------


                case (int)Menu.CreateEmployee:
                    try
                    {
                        Console.WriteLine("Enter Employee Name:");
                        string? empName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Surname:");
                        string? empSurName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Address:");
                        string? empAddress = Console.ReadLine();
                        Console.WriteLine("Enter Employee Salary:");
                        decimal empSalary = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter Employee Age:");
                        int empAge = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-----------------------");
                        departmentService.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter Department Id:");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        employeeService.Create(empName, empSurName, empSalary, departmentId,empAge,empAddress);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.ShowAllEmployee:
                    Console.WriteLine("All Employee:");
                    employeeService.ShowAll();
                    break;
                case (int)Menu.FindEmployeeByName:
                    try
                    {
                        Console.WriteLine("Enter Employee Name:");
                        string? empName = Console.ReadLine();
                        employeeService.GetEmployeeByName(empName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.FindEmployeeById:
                    try
                    {
                        Console.WriteLine("Enter Employee Id:");
                        int empId = Convert.ToInt32(Console.ReadLine());
                        employeeService.GetEmployeeById(empId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.UpdateEmployee:
                    try
                    {
                        Console.WriteLine("Enter Employee Id:");
                        int empId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Employee Name:");
                        string? empName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Surname:");
                        string? empSurName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Address:");
                        string? empAddress = Console.ReadLine();
                        Console.WriteLine("Enter Employee Salary:");
                        decimal empSalary = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter Employee Age:");
                        int empAge = Convert.ToInt32(Console.ReadLine());
               
                        employeeService.Update(empId,empName,empSurName,empSalary,empAge,empAddress);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.DeleteEmployee:
                    try
                    {
                        Console.WriteLine("Enter Employee Id:");
                        int empId = Convert.ToInt32(Console.ReadLine());
                        employeeService.Delete(empId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.MoveEmployee:
                    try
                    {
                        Console.WriteLine("----------employees-------------");
                        employeeService.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter Employee ID");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-----------departments------------");
                        departmentService.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter Department ID:");
                        int departmentId =Convert.ToInt32(Console.ReadLine());
                        employeeService.ChangeDepartment(employeeId, departmentId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    isContinue = false;
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please enter correct option number!");
        }
    }
    else
    {
        Console.WriteLine("Please enter correct format!");
    }
}