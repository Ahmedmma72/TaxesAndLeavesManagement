namespace company_managment.Services.Taxes;

public interface ITaxCalculator
{
    decimal CalculateTaxes(decimal salary);
}
