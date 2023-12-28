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
                      "1 - Create Company \n" +
                      "2 - Show All Companies \n" +
                      "3 - Activate Company \n" +
                      "4 - Delete Company \n" +
                      "5 - Get Company By Name \n"+
                      "6 - Get Company Departments\n" +
                      "7 - Update Company\n" +
                      "\n" +
                      "-- Department--\n" +
                      "8 - Create Department \n" +
                      "9 - Show All Department \n" +
                      "10 - Activate Department \n" +
                      "11 - Delete Department \n" +
                      "12 - Get Deparment Employees \n" +
                      "13 - Get Deparment By Id \n" +
                      "14 - Update Department \n"+
                      "\n" +
                      "-- Employees--\n" +
                      "14 - Create Employee \n" +
                      "15 - Show All Employee \n" +

                      "\n" +
                      "16 - Get Company \n" +
                      "17 - Move Employee \n" +
                      "0 - Exit");

    string? option = Console.ReadLine();
    const int MaxMenu = 17;
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
                case (int)Menu.ActivateCompany:
                    if (companyService.IsCompanyExist() == false) Console.WriteLine("Company yoxdur:");
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.Activate(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.DeleteCompany:
                    if (companyService.IsCompanyExist() == false) Console.WriteLine("Company yoxdur:");
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.Delete(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.GetByNameCompany:
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.GetCompany(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.GetCompanyDepartments:
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.GetCompanyDepartments(companyName);
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
                        Console.WriteLine("Enter company name:");
                        string? companyName2 = Console.ReadLine();
                        departmentService.Create(departmentName, maxEmpCount, companyName2);
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

                case (int)Menu.ActivateDepartment:
                    try
                    {
                        Console.WriteLine("Enter department name:");
                        string? departmentName = Console.ReadLine();
                        departmentService.Activate(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.DeleteDepartment:
                    try
                    {
                        Console.WriteLine("Enter department name:");
                        string? departmentName = Console.ReadLine();
                        departmentService.Delete(departmentName);
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
                        Console.WriteLine("Enter Department Limit:");
                        int capacity = Convert.ToInt32(Console.ReadLine());
                        departmentService.Update(departmentId,departmentName,capacity);
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
                        Console.WriteLine("Enter Employee Salary:");
                        decimal? empSalary = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("-----------------------");
                        departmentService.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter Department Name:");
                        string? departmentName = Console.ReadLine();
                        employeeService.Create(empName, empSurName, empSalary, departmentName);
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
                case (int)Menu.getCompany:
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.GetCompany(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.moveEmployee:
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
                        Console.WriteLine("Enter Department name:");
                        string? deparmentName = Console.ReadLine();
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


// new refresh