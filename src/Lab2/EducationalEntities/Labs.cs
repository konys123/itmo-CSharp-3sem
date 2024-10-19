using Exception = System.Exception;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

public class Labs
{
    public Labs(User author, string name, string description, string evaluationCriteria, int maximumScore)
    {
        Author = author;
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        MaximumScore = maximumScore;
        Id = Guid.NewGuid();
    }

    public Labs(User author, string name, string description, string evaluationCriteria, int maximumScore, Guid id)
    {
        Author = author;
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        MaximumScore = maximumScore;
        Id = Guid.NewGuid();
        LaboratoryBased = id;
    }

    public Guid Id { get; }

    public Guid LaboratoryBased { get; private set; }

    public string Name { get; private set; }

    public int MaximumScore { get; private set; }

    public string Description { get; private set; }

    public string EvaluationCriteria { get; private set; }

    public User Author { get; }

    public void ChangeName(string name, User author)
    {
        if (author.Isu == Author.Isu)
        {
            Name = name;
            return;
        }

        throw new Exception();
    }

    public void ChangeMaximumScore(int maximumscore, User author)
    {
        if (author.Isu == Author.Isu)
        {
            MaximumScore = maximumscore;
            return;
        }

        throw new Exception();
    }

    public void ChangeEvaluationCriteria(string evaluationCriteria, User author)
    {
        if (author.Isu == Author.Isu)
        {
            EvaluationCriteria = evaluationCriteria;
            return;
        }

        throw new Exception();
    }

    public void ChangeDescription(string description, User author)
    {
        if (author.Isu == Author.Isu)
        {
            Description = description;
            return;
        }

        throw new Exception();
    }
}