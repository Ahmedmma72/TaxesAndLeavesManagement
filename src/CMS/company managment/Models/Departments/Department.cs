using company_managment.Models.Employees;
using company_managment.Services.Taxes;

namespace company_managment.Models.Departments;

public abstract class Department
{
    public List<Employee> Employees { get; }
    private readonly ITaxCalculator _taxCalculator;

    public Department( ITaxCalculator taxCalculator)
    {
        _taxCalculator = taxCalculator;
        Employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }
    Employee? GetEmployee(int id)
    {
        return Employees.FirstOrDefault(e => e.Id == id);
    }
    public bool RemoveEmployee(int id)
    {
        var employee = GetEmployee(id);
        if (employee != null)
        {
            Employees.Remove(employee);
            return true;
        }
        return false;
    }
    public List<KeyValuePair<Employee, decimal>> GetEmployeesWithTaxes()
    {
        var employeesWithTaxes = new List<KeyValuePair<Employee, decimal>>();
        foreach (var employee in Employees)
        {
            var tax = _taxCalculator.CalculateTaxes(employee.Salary);
            employeesWithTaxes.Add(new KeyValuePair<Employee, decimal>(employee, tax));
        }
        return employeesWithTaxes;
    }

}
