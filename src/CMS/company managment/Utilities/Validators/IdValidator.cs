

namespace company_managment.Utilities.Validators;

public class IdValidator : IValidate<string?, int?>
{
    public int? Validate(string? obj)
    {
        if (obj == null)
        {
            return null;
        }
        if (int.TryParse(obj, out int id))
        {
            return id;
        }
        return null;
        
    }
}
