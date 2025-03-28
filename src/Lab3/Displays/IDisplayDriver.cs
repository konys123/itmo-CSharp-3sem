namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    public void SetColor(string color);

    public void WriteText(string text);
}