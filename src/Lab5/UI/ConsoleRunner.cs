using Itmo.ObjectOrientedProgramming.Lab5.Application;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.UI;

public class ConsoleRunner
{
    private readonly AtmApplication _app;
    private readonly string _adminPassword;

    public ConsoleRunner(AtmApplication app, string adminPassword)
    {
        _app = app;
        _adminPassword = adminPassword;
    }

    public void Run()
    {
        while (true)
        {
            string mode = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Выберите режим работы:")
                    .AddChoices("Пользователь", "Администратор", "Выход"));

            if (mode == "Выход") break;

            if (mode == "Администратор")
            {
                string pass = AnsiConsole.Prompt(new TextPrompt<string>("Введите системный пароль:").Secret());
                if (pass != _adminPassword)
                {
                    AnsiConsole.Markup("[red]Неверный пароль. Завершение работы.[/]");
                    return;
                }

                bool adminSession = true;
                while (adminSession)
                {
                    string adminChoice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Выберите операцию:")
                            .AddChoices("Создать счет", "Назад"));

                    if (adminChoice == "Создать счет")
                    {
                        try
                        {
                            string accNum = AnsiConsole.Ask<string>("Введите номер счета:");
                            string pin = AnsiConsole.Prompt(new TextPrompt<string>("Введите PIN:").Secret());
                            _app.CreateAccount(accNum, pin);
                            AnsiConsole.Markup("[green]Счет создан успешно![/]");
                        }
                        catch (Exception ex)
                        {
                            AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
                        }
                    }
                    else if (adminChoice == "Назад")
                    {
                        adminSession = false;
                        break;
                    }
                }
            }
            else if (mode == "Пользователь")
            {
                string accNum = AnsiConsole.Ask<string>("Введите номер счета:");
                string pin = AnsiConsole.Prompt(new TextPrompt<string>("Введите PIN:").Secret());

                if (!_app.Authorization(accNum, pin)) throw new ArgumentException("неверный логин или пароль");

                bool userSession = true;
                while (userSession)
                {
                    string userChoice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Выберите операцию:")
                            .AddChoices(
                                "Просмотр баланса",
                                "Снять деньги",
                                "Пополнить счет",
                                "История операций",
                                "Выход"));

                    switch (userChoice)
                    {
                        case "Просмотр баланса":
                            try
                            {
                                _app.ShowBalance(accNum);
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
                            }

                            break;

                        case "Снять деньги":
                            decimal withdrawAmount = AnsiConsole.Ask<int>("Сумма для снятия:");
                            try
                            {
                                _app.Withdraw(accNum, withdrawAmount);
                                AnsiConsole.MarkupLine("[green]Операция успешна[/]");
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
                            }

                            break;

                        case "Пополнить счет":
                            decimal depositAmount = AnsiConsole.Ask<int>("Сумма для пополнения:");
                            try
                            {
                                _app.Deposit(accNum, depositAmount);
                                AnsiConsole.MarkupLine("[green]Операция успешна[/]");
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
                            }

                            break;

                        case "История операций":
                            try
                            {
                                _app.ShowHistory(accNum);
                            }
                            catch (Exception ex)
                            {
                                AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
                            }

                            break;

                        case "Выход":
                            userSession = false;
                            break;
                    }
                }
            }
        }
    }
}