using company_managment.Services.LeavesManagement.Leaves;
using company_managment.Services.LeavesManagement.Requests;

namespace company_managment.Models.Employees;

public abstract class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public decimal Salary { get; set; }

    public List<Leave> Leaves { get;}
    public List<Request> LeavesHistories { get; set; }

    public Employee(int id, string fullName, decimal salary,List<Request> leavesHistories)
    {
        Id = id;
        FullName = fullName;
        Salary = salary;
        Leaves = LeavesFactory.getListOfLeaves();
        LeavesHistories = leavesHistories;
    }
    public Leave? getLeaveWithName(string name)
    {
        return Leaves.FirstOrDefault(l => l.GetType().Name == name);
    }
}
