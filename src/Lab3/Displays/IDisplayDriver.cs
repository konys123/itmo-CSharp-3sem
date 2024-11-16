namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    void SetColor(string color);

    void WriteText(string text);
}