using company_managment.Services.LeavesManagement.Leaves;
using company_managment.Services.LeavesManagement.Requests;

namespace company_managment.Models.Employees;

public class InternEmployee : Employee
{
    public InternEmployee(int id, string fullName, decimal salary, List<Request> leavesHistories) : base(id, fullName, salary, leavesHistories)
    {
    }
}
