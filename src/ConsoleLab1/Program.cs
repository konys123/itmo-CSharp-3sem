using Itmo.ObjectOrientedProgramming.Lab1;

namespace ConsoleLab1;

public class Program
{
    public static void Main()
    {
        var train = new Train(10, 500);
        var s1 = new PowerMagneticPaths(110, 500);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1];
        var route = new Route(sections, 1f, train, 104);
        bool res = route.TryToComplete();
        Console.WriteLine(res);
    }
}