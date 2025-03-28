using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LabsBuilder
{
    private User? _author;
    private string? _name;
    private string? _description;
    private string? _evaluationCriteria;
    private int _maximumScore;

    public LabsBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public LabsBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LabsBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LabsBuilder SetEvaluationCriteria(string evaluationCriteria)
    {
        _evaluationCriteria = evaluationCriteria;
        return this;
    }

    public LabsBuilder SetMaximumScore(int maximumScore)
    {
        _maximumScore = maximumScore;
        return this;
    }

    public Labs Build()
    {
        if (_author == null || _name == null || _description == null || _evaluationCriteria == null)
            throw new InvalidOperationException();
        return new Labs(_author, _name, _description, _evaluationCriteria, _maximumScore);
    }
}