using company_managment.Models.Departments;
using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Requests;
using company_managment.Services.Taxes;

namespace company_managment.Utilities.Loaders;

public class DepartmentLoader : ILoad<Department>
{
    
    private readonly ITaxCalculator _taxCalculator;

    public DepartmentLoader(ITaxCalculator taxCalculator)
    {
        _taxCalculator = taxCalculator;
    }
    public List<Department> Load()
    {
        List<Department> departments = new List<Department>
        {
            new HR(_taxCalculator),
            new Finance(_taxCalculator),
            new Sales(_taxCalculator),
            new Marketing(_taxCalculator),
            new Operations(_taxCalculator),
        };
        // populate all departments with employees of different types
        departments[0].AddEmployee(new FullTimeEmployee(1, "Ahmed", 25000, new List<Request>()));
        departments[0].AddEmployee(new PartTimeEmployee(2,"Mohamed",15000, new List<Request>()));
        departments[0].AddEmployee(new InternEmployee(3,"Ali",5000,new List<Request>()));
        departments[1].AddEmployee(new FullTimeEmployee(4,"Sara",70000,new List<Request>()));
        departments[1].AddEmployee(new FullTimeEmployee(5,"Nada",55000,new List<Request>()));
        departments[1].AddEmployee(new PartTimeEmployee(6,"Hana",40000,new List<Request>()));
        departments[2].AddEmployee(new InternEmployee(7,"Hassan",10000,new List<Request>()));
        departments[2].AddEmployee(new FullTimeEmployee(8,"Omar",30000,new List<Request>()));
        departments[2].AddEmployee(new PartTimeEmployee(9,"Khaled",350000,new List<Request>()));
        departments[3].AddEmployee(new FullTimeEmployee(10,"Hussein",45000,new List<Request>()));
        departments[3].AddEmployee(new PartTimeEmployee(11,"Hoda",20000,new List<Request>()));
        departments[3].AddEmployee(new InternEmployee(12,"Nour",6000,new List<Request>()));
        departments[4].AddEmployee(new FullTimeEmployee(13,"Mona",80000,new List<Request>()));
        departments[4].AddEmployee(new PartTimeEmployee(14,"Noha",25000,new List<Request>()));
        departments[4].AddEmployee(new InternEmployee(15,"Nael",7000,new List<Request>()));
        return departments;
        
    }
}
