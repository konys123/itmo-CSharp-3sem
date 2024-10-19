namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

public class LectureMaterials
{
    public LectureMaterials(User author, string name, string description, string content)
    {
        Author = author;
        Name = name;
        Description = description;
        Content = content;
        Id = Guid.NewGuid();
    }

    public LectureMaterials(User author, string name, string description, string content, Guid id)
    {
        Author = author;
        Name = name;
        Description = description;
        Content = content;
        Id = Guid.NewGuid();
        LectureMaterialBased = id;
    }

    public Guid Id { get; init; }

    public Guid LectureMaterialBased { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public User Author { get; init; }

    public void ChangeName(string name, User author)
    {
        if (author.Isu == Author.Isu)
        {
            Name = name;
            return;
        }

        throw new Exception();
    }

    public void ChangeEvaluationCriteria(string evaluationCriteria, User author)
    {
        if (author.Isu == Author.Isu)
        {
            Content = evaluationCriteria;
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