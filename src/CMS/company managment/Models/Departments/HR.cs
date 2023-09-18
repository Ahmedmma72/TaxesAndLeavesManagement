using company_managment.Services.Taxes;


namespace company_managment.Models.Departments;

public class HR : Department
{
    public HR(ITaxCalculator taxCalculator) : base(taxCalculator)
    {
    }
}
