namespace company_managment.Utilities.Validators;

public class ChoiceValidator: IValidate<string?, int?>
{
    public int MaxRange { get; set; }
    public ChoiceValidator(int maxRange)
    {
        MaxRange = maxRange;
    }
    public int? Validate(string? value)
    {
        int choice;
        if (int.TryParse(value, out choice))
            if (choice >= 1 && choice <= MaxRange)
            {
                return choice - 1;
            }
        return null;
    }
}