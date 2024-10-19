namespace Itmo.ObjectOrientedProgramming.Lab2;

public class User
{
    public User(string name)
    {
        Isu = Guid.NewGuid();
        Name = name;
    }

    public Guid Isu { get; }

    public string Name { get; set; }
}