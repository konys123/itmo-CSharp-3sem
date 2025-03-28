using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

public class Subject : IPrototype<Subject>
{
    public Subject(
        User author,
        string name,
        IEnumerable<Labs> labs,
        IEnumerable<LectureMaterials> lectures,
        string format,
        int points)
    {
        Author = author;
        Name = name;
        Lectures = lectures.ToList();
        Labs = labs.ToList();
        Id = Guid.NewGuid();
        Format = format;
        if (format == "экзамен")
        {
            ExamPoints = points;
        }
        else if (format == "зачет")
        {
            MinPoints = points;
        }

        if (!IsHundredPoints())
        {
            throw new Exception();
        }
    }

    public Subject(
        User author,
        string name,
        IEnumerable<Labs> labs,
        IEnumerable<LectureMaterials> lectures,
        string format,
        int points,
        Guid id)
    {
        Author = author;
        Name = name;
        Lectures = lectures.ToList();
        Labs = labs.ToList();
        Id = Guid.NewGuid();
        Format = format;
        if (format == "экзамен")
        {
            ExamPoints = points;
        }
        else if (format == "зачет")
        {
            MinPoints = points;
        }

        if (!IsHundredPoints())
        {
            throw new Exception();
        }

        Based = id;
    }

    public Guid Id { get; init; }

    public Guid Based { get; private set; }

    public int ExamPoints { get; private set; }

    public int MinPoints { get; private set; }

    public string Name { get; private set; }

    public string Format { get; private set; }

    public User Author { get; init; }

    public IEnumerable<Labs> Labs { get; private set; }

    public IEnumerable<LectureMaterials> Lectures { get; private set; }

    public void ChangeLectures(IEnumerable<LectureMaterials> lec, User author)
    {
        if (author.Isu == Author.Isu)
        {
            Lectures = lec.ToList();
            return;
        }

        throw new Exception();
    }

    public void ChangeLabs(IEnumerable<Labs> lab, User author)
    {
        if (author.Isu == Author.Isu)
        {
            Labs = lab.ToList();
            if (IsHundredPoints()) return;
        }

        throw new Exception();
    }

    public Subject Clone()
    {
        var lab = new List<Labs>();
        var lec = new List<LectureMaterials>();

        foreach (Labs i in Labs)
        {
            Labs tmp = i.Clone();
            lab.Add(tmp);
        }

        foreach (LectureMaterials i in Lectures)
        {
            LectureMaterials tmp = i.Clone();
            lec.Add(tmp);
        }

        if (Format == "экзамен")
        {
            return new Subject(
                Author,
                Name,
                lab,
                lec,
                Format,
                ExamPoints,
                Id);
        }

        return new Subject(
            Author,
            Name,
            lab,
            lec,
            Format,
            MinPoints,
            Id);
    }

    private bool IsHundredPoints()
    {
        int sum = 0;
        foreach (Labs lab in Labs)
        {
            sum += lab.MaximumScore;
        }

        if (Format == "экзамен")
        {
            sum += ExamPoints;
        }

        if (sum == 100)
        {
            return true;
        }

        return false;
    }
}