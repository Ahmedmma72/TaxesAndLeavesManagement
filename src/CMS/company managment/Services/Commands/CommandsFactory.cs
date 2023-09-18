using company_managment.CompanyWrapper;
using company_managment.Consoles;
using company_managment.Services.Commands.Choices;
using company_managment.Utilities.Validators;
namespace company_managment.Services.Commands;

public static class CommandsFactory
{
    public static List<ICommand> CreateCommands(IConsole console,
                                                ICompany company,
                                                IValidate<decimal, decimal?> salaryValidator,
                                                IValidate<string?, int?> idValidator,
                                                IValidate<string?, int?> choiceValidator,
                                                Dictionary<int, string> typesOfLeavesMap)
    {
        List<ICommand> commands = new List<ICommand>
        {
            //new AddEmployee(console, company, salaryValidator),
            new ShowEmployees(console, company),
            new RequestLeave(console, company, idValidator,choiceValidator ,typesOfLeavesMap)
        };
        return commands;
    }

}
