namespace company_managment.Services.Taxes.US;


public class USTaxesCalculation : ITaxCalculator
{
    public decimal CalculateTaxes(decimal salary)
    {
        decimal taxRate;
        decimal fixedTax;

        if (salary < BucketsEndLimits.First)
        {
            taxRate = TaxRates.First;
            fixedTax = FixedBucketTaxes.First;
        }
        else if (salary < BucketsEndLimits.Second)
        {
            taxRate = TaxRates.Second;
            fixedTax = FixedBucketTaxes.Second;
        }
        else if (salary < BucketsEndLimits.Third)
        {
            taxRate = TaxRates.Third;
            fixedTax = FixedBucketTaxes.Third;
        }
        else if (salary < BucketsEndLimits.Fourth)
        {
            taxRate = TaxRates.Fourth;
            fixedTax = FixedBucketTaxes.Fourth;
        }
        else if (salary < BucketsEndLimits.Fifth)
        {
            taxRate = TaxRates.Fifth;
            fixedTax = FixedBucketTaxes.Fifth;
        }
        else if (salary < BucketsEndLimits.Sixth)
        {
            taxRate = TaxRates.Sixth;
            fixedTax = FixedBucketTaxes.Sixth;
        }
        else if (salary < BucketsEndLimits.Seventh)
        {
            taxRate = TaxRates.Seventh;
            fixedTax = FixedBucketTaxes.Seventh;
        }
        else if (salary < BucketsEndLimits.Eighth)
        {
            taxRate = TaxRates.Eighth;
            fixedTax = FixedBucketTaxes.Eighth;
        }
        else
        {
            taxRate = TaxRates.Ninth;
            fixedTax = FixedBucketTaxes.Ninth;
        }
        return taxRate * salary + fixedTax;

    }
}
