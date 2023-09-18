using company_managment.Services.LeavesManagement.PoliciesManagers;

namespace company_managment.Services.LeavesManagement.Leaves;

public class CasualLeave : Leave
{
    public CasualLeave(int balance=8) : base(balance)
    {
        LeavePolicy = typeof(CasualLeavePoliciesManager);
    }
}
