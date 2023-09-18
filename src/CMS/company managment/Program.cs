using company_managment.Consoles;
using company_managment.Utilities.Validators;
using company_managment.CompanyWrapper;
using company_managment.Utilities.Loaders;
using company_managment.Services.Taxes.US;
using company_managment.Services.Commands;
using company_managment.Services.LeavesManagement;
using company_managment.Services.LeavesManagement.PoliciesManagers;
using company_managment.Services.LeavesManagement.Leaves;

namespace company_managment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var console = new RealConsole();
            var usTaxCalculator = new USTaxesCalculation();
            string name= "Company";
            var departmentLoader = new DepartmentLoader(usTaxCalculator);
            List<LeavePoliciesManager> leavePolicies = LeavesPoliciesManagerFactory.GetLeavePolicies();
            ILeavesManager leavesManager = new LeavesManager(leavePolicies);
            var company = new Company(name, departmentLoader,leavesManager);
            var salaryValidator = new SalaryValidator();
            var idValidator = new IdValidator();
            var typesOfLeavesMap = LeavesFactory.TypesOfLeavesMap();
            var choiceValidator = new ChoiceValidator(typesOfLeavesMap.Count);
            List<ICommand> commands = CommandsFactory.CreateCommands(console,company, salaryValidator,idValidator,choiceValidator,typesOfLeavesMap);
            var mainMenuChoiceValidator = new ChoiceValidator(commands.Count);
            var ui = new UI.ConsoleUI(console,mainMenuChoiceValidator,commands);
            ui.Run();
        }
    }
}