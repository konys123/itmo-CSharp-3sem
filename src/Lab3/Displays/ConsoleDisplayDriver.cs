namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public void SetColor(string color)
    {
        if (color == "Red") Console.ForegroundColor = ConsoleColor.Red;
        if (color == "Green") Console.ForegroundColor = ConsoleColor.Green;
        if (color == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
        else Console.ForegroundColor = ConsoleColor.Black;
    }

    public void WriteText(string text)
    {
        Console.Clear();
        Console.WriteLine(text);
    }
}