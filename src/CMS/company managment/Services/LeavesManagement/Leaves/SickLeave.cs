using company_managment.Services.LeavesManagement.PoliciesManagers;

namespace company_managment.Services.LeavesManagement.Leaves;

public class SickLeave : Leave
{
    public SickLeave(int balance = 15) : base(balance)
    {
        LeavePolicy = typeof(SickLeavePoliciesManager);
    }
}
