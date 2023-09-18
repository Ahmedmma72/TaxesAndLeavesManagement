using company_managment.Models.Departments;
using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement;
using company_managment.Services.LeavesManagement.Requests;
using company_managment.Utilities.Loaders;

namespace company_managment.CompanyWrapper;

public class Company : ICompany
{
    public List<Department> Departments { get; }
    public ILeavesManager LeavesManager { get; }

    public string Name { get; }

    private readonly ILoad<Department> _departemntsLoader;

    public Company(string name, ILoad<Department> departemntsLoader,ILeavesManager leavesManager)
    {
        Name = name;
        _departemntsLoader = departemntsLoader;
        Departments = _departemntsLoader.Load();
        LeavesManager = leavesManager;
    }
    public bool AddEmployee(Employee employee, string departmentName)
    {
        Department? department = Departments.FirstOrDefault(d => d.GetType().Name == departmentName);
        if (department == null)
        {
            return false;
        }
        return true;
    }

    public Employee? GetEmployee(int id)
    {   
        foreach (var department in Departments)
        {
            foreach (var employee in department.Employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }
        }
        return null;

    }
    public bool RemoveEmployee(int id, string departmentName)
    {
        Department? department = Departments.FirstOrDefault(d => d.GetType().Name == departmentName);
        if (department == null)
        {
            return false;
        }
        return department.RemoveEmployee(id); 
    }
    public RequestMessage RequestLeave(Request request, Employee employee)
    {
        return LeavesManager.HandleRequest(request, employee);
    }
}
