using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Requests;


namespace company_managment.Services.LeavesManagement.PolicyHandlers;

public class EnoughBalancePolicy : PolicyHandler
{
    public override RequestMessage Handle(Request request, Employee employee)
    {
        // Check if the employee has enough balance to request this leave
        var leave = employee.Leaves.FirstOrDefault(l => l.GetType().Name == request.LeaveType);
        if (leave != null && leave.Balance >= request.Duration)
        {
            return HandleNext(request, employee);
        }
        return new RequestMessage("You don't have enough balance to request this leave");
    }
}
