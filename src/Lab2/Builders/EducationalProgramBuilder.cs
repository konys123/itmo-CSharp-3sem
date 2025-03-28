using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class EducationalProgramBuilder
{
    private readonly List<Subject> _subjects = new List<Subject>();
    private readonly List<Subject> _firstSemesterSubjects = new List<Subject>();
    private readonly List<Subject> _secondSemesterSubjects = new List<Subject>();
    private string? _name;
    private User? _author;

    public EducationalProgramBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public EducationalProgramBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public EducationalProgramBuilder AddSubject(Subject subject)
    {
        _subjects.Add(subject);
        return this;
    }

    public EducationalProgramBuilder AddFirstSemesterSubject(Subject subject)
    {
        _firstSemesterSubjects.Add(subject);
        return this;
    }

    public EducationalProgramBuilder AddSecondSemesterSubject(Subject subject)
    {
        _secondSemesterSubjects.Add(subject);
        return this;
    }

    public EducationalProgram Build()
    {
        if (_name == null || _author == null || _subjects == null || _firstSemesterSubjects == null ||
            _secondSemesterSubjects == null)
        {
            throw new InvalidOperationException("Program name must be set before building.");
        }

        return new EducationalProgram(_name, _subjects, _author, _firstSemesterSubjects, _secondSemesterSubjects);
    }
}