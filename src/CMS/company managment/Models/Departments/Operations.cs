using company_managment.Services.Taxes;

namespace company_managment.Models.Departments;

public class Operations : Department
{
    public Operations(ITaxCalculator taxCalculator) : base(taxCalculator)
    {
    }
}
