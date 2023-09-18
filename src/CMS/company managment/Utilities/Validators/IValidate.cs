namespace company_managment.Utilities.Validators;

public interface IValidate<T,U>
{
   public U Validate(T obj);
}
