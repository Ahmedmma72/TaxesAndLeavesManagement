namespace company_managment.Services.Commands;

public interface ICommand
{
    public string Message();
    public void Execute();

}
