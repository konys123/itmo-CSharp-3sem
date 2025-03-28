namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class FileDisplayDriver : IDisplayDriver
{
    private string FilePath { get; set; } =
        "C:\\Users\\kinys\\Desktop\\testik.html";

    private string Color { get; set; } = "Black";

    public void SetColor(string color)
    {
        Color = color;
    }

    public void WriteText(string text)
    {
        string htmlTemplate = $@"
            <html>
            <head><title>Colored Text</title></head>
            <body style='font-family: Arial; font-size: 14px;'>
                <span style='color: {Color};'>{text}</span>
            </body>
            </html>";
        File.WriteAllText(FilePath, htmlTemplate);
    }
}