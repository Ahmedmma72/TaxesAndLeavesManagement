using company_managment.Services.Taxes;


namespace company_managment.Models.Departments;

public class Marketing : Department
{
    public Marketing(ITaxCalculator taxCalculator) : base(taxCalculator)
    {
    }
}
