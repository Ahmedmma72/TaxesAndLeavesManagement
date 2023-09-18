using company_managment.Models.Departments;
using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement;
using company_managment.Services.LeavesManagement.Requests;

namespace company_managment.CompanyWrapper;

public interface ICompany
{
    List<Department> Departments { get; }
    public ILeavesManager LeavesManager { get; }
    string Name { get; }
    bool AddEmployee(Employee employee,string departmentName);
    Employee? GetEmployee(int id);
    bool RemoveEmployee(int id,string departmentName);

    RequestMessage RequestLeave(Request request,Employee employee);
}