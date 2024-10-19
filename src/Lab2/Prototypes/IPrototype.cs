namespace Itmo.ObjectOrientedProgramming.Lab2.Prototypes;

public interface IPrototype<T>
{
    public T Clone(T based);
}