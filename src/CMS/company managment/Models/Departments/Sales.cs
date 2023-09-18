using company_managment.Services.Taxes;


namespace company_managment.Models.Departments;

public class Sales : Department
{
    public Sales(ITaxCalculator taxCalculator) : base(taxCalculator)
    {
    }
}
