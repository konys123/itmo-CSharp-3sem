namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

public class EducationalProgram
{
    public EducationalProgram(
        string name,
        IEnumerable<Subject> subjects,
        User author,
        IEnumerable<Subject> firstSemester,
        IEnumerable<Subject> secondSemester)
    {
        Id = Guid.NewGuid();
        Name = name;
        Subjects = subjects;
        Author = author;
        Semesters = [firstSemester, secondSemester];
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public User Author { get; private set; }

    public IEnumerable<Subject> Subjects { get; private set; }

    public IEnumerable<IEnumerable<Subject>> Semesters { get; private set; }
}