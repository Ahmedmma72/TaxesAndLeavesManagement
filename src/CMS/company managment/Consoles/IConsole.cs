namespace company_managment.Consoles;

public interface IConsole 
{
    void WriteLine(string message);
    void Write(string message);
    string? ReadLine();
    void Clear();
}
