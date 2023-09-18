namespace company_managment.Consoles;

public class RealConsole: IConsole
{
    public void Clear()
    {
        Console.Clear();
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }

    public void Write(string message)
    {
        Console.Write(message);
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

}
