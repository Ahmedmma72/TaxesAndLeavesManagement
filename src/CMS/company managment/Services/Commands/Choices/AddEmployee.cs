using company_managment.CompanyWrapper;
using company_managment.Consoles;
using company_managment.Utilities.Validators;

namespace company_managment.Services.Commands.Choices;

public class AddEmployee : ICommand
{
    private readonly IConsole _console;
    private readonly ICompany _company;
    private readonly IValidate<decimal, decimal?> _salaryValidator;

    public AddEmployee(IConsole console, ICompany company, IValidate<decimal, decimal?> salaryValidator)
    {
        _console = console;
        _company = company;
        _salaryValidator = salaryValidator;
    }
    public string Message()
    {
        return "Add Employee";
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }

}
