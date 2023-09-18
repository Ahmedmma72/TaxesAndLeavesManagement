using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Requests;


namespace company_managment.Services.LeavesManagement.PolicyHandlers;

public class SameMonthPolicy : PolicyHandler
{
    public override RequestMessage Handle(Request request, Employee employee)
    {
        var caualLeaves = employee.LeavesHistories.Where(l => l.LeaveType == request.LeaveType).ToList();
        foreach (var leave in caualLeaves)
        {
            if (leave.StartDate.Month == request.StartDate.Month || leave.StartDate.AddDays(leave.Duration).Month == request.StartDate.Month)
            {
                return new RequestMessage("You can't request a leave in the same month of another leave");
            }
        }
        return HandleNext(request, employee);
    }
}
