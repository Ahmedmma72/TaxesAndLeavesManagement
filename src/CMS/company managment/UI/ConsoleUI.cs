using company_managment.Consoles;
using company_managment.Utilities.Validators;
using company_managment.Services.Commands;
using System;

namespace company_managment.UI;

internal class ConsoleUI : IConsoleUI
{
    private readonly IConsole _console;
    private readonly IValidate<string?,int?> _mainMenuChoiceValidator;
    private readonly List<ICommand> _commands;

    public ConsoleUI(IConsole console, IValidate<string?, int?> mainMenuChoiceValidator, List<ICommand> commands)
    {
        _console = console;
        _mainMenuChoiceValidator = mainMenuChoiceValidator;
        _commands = commands;
    }
    public void Run()
    {
        while (true)
        {
            _console.WriteLine("--------------------");
            _console.WriteLine("Main Menu:");
            for (int i = 0; i < _commands.Count; i++)
            {
                _console.WriteLine($"{i + 1}. {_commands[i].Message()}");
            }
            _console.WriteLine("--------------------");
            _console.Write("Select an option: ");
            string? choiceAsString = _console.ReadLine();
            int? choice = _mainMenuChoiceValidator.Validate(choiceAsString);
            if (choice == null)
            {
                _console.WriteLine("Invalid option, Please try again");
                continue;
            }
            _commands[choice.Value].Execute();
        }

    }
}
