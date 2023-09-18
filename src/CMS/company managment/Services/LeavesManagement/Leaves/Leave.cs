using company_managment.Services.LeavesManagement.PoliciesManagers;

namespace company_managment.Services.LeavesManagement.Leaves;

public abstract class Leave
{
    public int Balance { get; protected set; }

    public Type LeavePolicy { get; set; } = typeof(LeavePoliciesManager);

    public Leave(int balance)
    {
        Balance = balance;
    }
    public bool ReduceBalance(int days)
    {
        if (Balance >= days)
        {
            Balance -= days;
            return true;
        }
        return false;
    }
}
