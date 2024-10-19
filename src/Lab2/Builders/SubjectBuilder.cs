using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SubjectBuilder
{
    private User? _author;
    private string? _name;
    private IEnumerable<Labs>? _labs;
    private IEnumerable<LectureMaterials>? _lectures;
    private string? _format;
    private int _points;

    public SubjectBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public SubjectBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public SubjectBuilder SetLabs(IEnumerable<Labs> labs)
    {
        _labs = labs;
        return this;
    }

    public SubjectBuilder SetLectures(IEnumerable<LectureMaterials> lectures)
    {
        _lectures = lectures;
        return this;
    }

    public SubjectBuilder SetFormat(string format)
    {
        _format = format;
        return this;
    }

    public SubjectBuilder SetPoints(int points)
    {
        _points = points;
        return this;
    }

    public Subject Build()
    {
        if (_author == null || _name == null || _labs == null || _lectures == null || _format == null)
            throw new InvalidOperationException();
        return new Subject(_author, _name, _labs, _lectures, _format, _points);
    }
}
