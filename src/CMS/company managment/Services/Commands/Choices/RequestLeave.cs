using company_managment.CompanyWrapper;
using company_managment.Consoles;
using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Leaves;
using company_managment.Services.LeavesManagement.Requests;
using company_managment.Utilities.Validators;

namespace company_managment.Services.Commands.Choices;

public class RequestLeave : ICommand
{
    private readonly IConsole _console;
    private readonly ICompany _company;
    private readonly IValidate<string?,int?> _idValidator;
    private readonly IValidate<string?,int?> _choiceValidator;
    private readonly Dictionary<int, string> _typesOfLeavesMap;

    public RequestLeave(IConsole console,
                        ICompany company,
                        IValidate<string?, int?> idValidator,
                        IValidate<string?, int?> choiceValidator,
                        Dictionary<int, string> typesOfLeavesMap)
    {
        _console = console;
        _company = company;
        _idValidator = idValidator;
        _choiceValidator = choiceValidator;
        _typesOfLeavesMap = typesOfLeavesMap;
    }
    public void Execute()
    {
        Employee employee = GetEmployee();

        string leaveType = GetLeaveType();

        DateOnly startDate = GetStartDate();

        int days = GetDays();

        RequestMessage status = _company.RequestLeave(new Request(leaveType, startDate, days), employee);
        _console.WriteLine(status.Message);
        if (status.IsApproved)
        {
            Leave? leave = employee.getLeaveWithName(leaveType);
            if (leave != null)
            {
                _console.WriteLine($"Leave days left for: {leaveType} is {leave.Balance}");
            }
        }
        else
        {
            _console.WriteLine($"Leave request was not approved");
        }
    }
    private Employee GetEmployee()
    {
        int id = ReadID();
        // Now check if the id exists in the company
        var employee = _company.GetEmployee(id);
        while (employee == null)
        {
            _console.WriteLine("this id does not exist, please try again:");
            id = ReadID();
            employee = _company.GetEmployee(id);
        }
        return employee;
    }
    private int ReadID()
    { 
        _console.WriteLine("Enter employee id:");
        string? stringId = _console.ReadLine();
        int? id = _idValidator.Validate(stringId);
        while(id == null)
        {
            _console.WriteLine("Invalid id, please try again:");
            stringId = _console.ReadLine();
            id = _idValidator.Validate(stringId);
        }
        return id.Value;
    }
    private string GetLeaveType()
    {
        
        _console.WriteLine("types of Leaves:");
        foreach (var type in _typesOfLeavesMap)
        {
            _console.WriteLine($"{type.Key} - {type.Value}");
        }
        _console.WriteLine("Choose the type of leave you want to request:");
        string? stringChoice = _console.ReadLine();
        int? choice = _choiceValidator.Validate(stringChoice);
        while (choice == null)
        {
            _console.WriteLine("Invalid choice, please try again:");
            stringChoice = _console.ReadLine();
            choice = _choiceValidator.Validate(stringChoice);
        }
        string leaveType = _typesOfLeavesMap[choice.Value+1];
        return leaveType;
    }

    private int GetDays()
    { 
        _console.WriteLine("Enter number of days:");
        string? stringDays = _console.ReadLine();
        int? days = int.TryParse(stringDays, out int result) ? result : null;
        while (days == null)
        {
            _console.WriteLine("Invalid number of days, please try again:");
            stringDays = _console.ReadLine();
            days = int.TryParse(stringDays, out result) ? result : null;
        }
        return days.Value;
    }

    private DateOnly GetStartDate()
    {
        _console.WriteLine("Enter start date:");
        string? stringStartDate = _console.ReadLine();
        DateOnly? startDate = DateOnly.TryParse(stringStartDate, out DateOnly result) ? result : null;
        // Now check if the date is valid and is in the future
        while (startDate == null || startDate.Value < DateOnly.FromDateTime(DateTime.Now))
        {
            _console.WriteLine("Invalid date, please try again:");
            stringStartDate = _console.ReadLine();
            startDate = DateOnly.TryParse(stringStartDate, out result) ? result : null;
        }
        return startDate.Value;

    }
    public string Message()
    {
        return "Request a Leave";
    }
}
