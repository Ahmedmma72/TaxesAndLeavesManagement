using company_managment.CompanyWrapper;
using company_managment.Consoles;


namespace company_managment.Services.Commands.Choices;

public class ShowEmployees : ICommand
{
    private readonly IConsole _console;
    private readonly ICompany _company;
    public ShowEmployees(IConsole console, ICompany company)
    {
        _console = console;
        _company = company;
    }
    public string Message()
    {
        return "Show Employees";
    }
    public void Execute()
    {
        _console.WriteLine($"Company name: {_company.Name}");
        foreach (var department in _company.Departments)
        {
            _console.WriteLine($"Department name: {department.GetType().Name}");
            foreach (var employeeWithTax in department.GetEmployeesWithTaxes())
            {
                _console.WriteLine($"ID: {employeeWithTax.Key.Id} - Employee name: {employeeWithTax.Key.FullName} - Salary: {employeeWithTax.Key.Salary} - Tax: {employeeWithTax.Value} - EmploymentType: {employeeWithTax.Key.GetType().Name}");
                // Now his leaves balance
                foreach (var leave in employeeWithTax.Key.Leaves)
                {
                    _console.WriteLine($"Leave type: {leave.GetType().Name} - Balance: {leave.Balance}");
                }
            }
        }
    }
}
