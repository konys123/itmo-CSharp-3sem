using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LectureMaterialsBuilder
{
    private User? _author;
    private string? _name;
    private string? _description;
    private string? _content;

    public LectureMaterialsBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public LectureMaterialsBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LectureMaterialsBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureMaterialsBuilder SetContent(string content)
    {
        _content = content;
        return this;
    }

    public LectureMaterials Build()
    {
        if (_author == null || _name == null || _description == null || _content == null)
            throw new InvalidOperationException();
        return new LectureMaterials(_author, _name, _description, _content);
    }
}
