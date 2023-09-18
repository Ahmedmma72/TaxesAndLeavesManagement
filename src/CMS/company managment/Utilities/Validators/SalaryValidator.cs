using company_managment.Models;

namespace company_managment.Utilities.Validators;

public class SalaryValidator: IValidate<decimal,decimal?>
{
    public decimal? Validate(decimal salary)
    {
        if (salary < 0)
        {
            return null;
        }
        return salary;
    }
}