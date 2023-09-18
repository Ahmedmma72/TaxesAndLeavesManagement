namespace company_managment.Utilities.Loaders;

public interface ILoad<T>
{
    List<T> Load();
}
