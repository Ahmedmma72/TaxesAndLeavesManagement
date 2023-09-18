using company_managment.Services.Taxes;


namespace company_managment.Models.Departments;

public class Finance : Department
{
    public Finance(ITaxCalculator taxCalculator) : base(taxCalculator)
    {
    }
}
