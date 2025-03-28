namespace Itmo.ObjectOrientedProgramming.Lab1;

public interface IRouteSection
{
    bool TryToPass(Train train, float accuracy);
}