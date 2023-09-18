
using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Leaves;
using company_managment.Services.LeavesManagement.PoliciesManagers;
using company_managment.Services.LeavesManagement.Requests;

namespace company_managment.Services.LeavesManagement;

public class LeavesManager : ILeavesManager
{
    private List<LeavePoliciesManager> _leavePolicies;

    public LeavesManager(List<LeavePoliciesManager> leavePolicies)
    {
        _leavePolicies = leavePolicies;
    }
    public RequestMessage HandleRequest(Request request, Employee employee)
    {
        var leave = employee.getLeaveWithName(request.LeaveType);
        if (leave == null)
        {
            return new RequestMessage("Leave type was not found");
        }
        var Policy = _leavePolicies.FirstOrDefault(x => x.GetType() == leave.LeavePolicy);
        if (Policy == null)
        {
            return new RequestMessage("No corresponding policy was found");
        }
        RequestMessage requestMessage = Policy.HandleRequest(request, employee);
        if (!requestMessage.IsApproved)
        {
            return requestMessage;
        }
        leave.ReduceBalance(request.Duration);
        employee.LeavesHistories.Add(request);
        return requestMessage;
    }
}
