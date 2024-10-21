using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;
using Xunit;

namespace Lab2.Tests;

public class Test2
{
    [Fact]
    public void TryChange1()
    {
        var auth = new User("s");
        var auth2 = new User("s");
        Labs a = new LabsBuilder()
            .SetAuthor(auth)
            .SetMaximumScore(100)
            .SetDescription(" ")
            .SetEvaluationCriteria(" ")
            .SetName("lab-2")
            .Build();
        Assert.Throws<Exception>(() => a.ChangeName("lab-1", auth2));
    }

    [Fact]
    public void TryChange2()
    {
        var auth = new User("s");
        var auth2 = new User("s");
        LectureMaterials a = new LectureMaterialsBuilder()
            .SetAuthor(auth)
            .SetDescription(" ")
            .SetName("lec-2")
            .SetContent(" ")
            .Build();
        Assert.Throws<Exception>(() => a.ChangeName("lec-1", auth2));
    }

    [Fact]
    public void TryChange3()
    {
        var auth = new User("s");
        var auth2 = new User("s");
        Labs a = new LabsBuilder()
            .SetAuthor(auth)
            .SetMaximumScore(100)
            .SetDescription(" ")
            .SetEvaluationCriteria(" ")
            .SetName("lab-2")
            .Build();
        LectureMaterials b = new LectureMaterialsBuilder()
            .SetAuthor(auth)
            .SetDescription(" ")
            .SetName(" ")
            .SetContent(" ")
            .Build();
        Subject c = new SubjectBuilder()
            .SetAuthor(auth)
            .SetName(" ")
            .SetFormat("зачет")
            .SetLabs([a])
            .SetLectures([b])
            .SetPoints(66)
            .Build();
        Assert.Throws<Exception>(() => c.ChangeLabs([a, a], auth2));
    }

    [Fact]
    public void CopyContainsSourceId1()
    {
        var auth = new User("s");
        Labs a = new LabsBuilder()
            .SetAuthor(auth)
            .SetMaximumScore(100)
            .SetDescription(" ")
            .SetEvaluationCriteria(" ")
            .SetName("lab-2")
            .Build();
        Labs b = a.Clone();
        Assert.True(b.LaboratoryBased == a.Id);
    }

    [Fact]
    public void CopyContainsSourceId2()
    {
        var auth = new User("s");
        LectureMaterials a = new LectureMaterialsBuilder()
            .SetAuthor(auth)
            .SetDescription(" ")
            .SetName("lec-2")
            .SetContent(" ")
            .Build();
        LectureMaterials b = a.Clone();
        Assert.True(b.LectureMaterialBased == a.Id);
    }

    [Fact]
    public void CopyContainsSourceId3()
    {
        var auth = new User("s");
        Labs a = new LabsBuilder()
            .SetAuthor(auth)
            .SetMaximumScore(50)
            .SetDescription(" ")
            .SetEvaluationCriteria(" ")
            .SetName("lab-2")
            .Build();
        LectureMaterials b = new LectureMaterialsBuilder()
            .SetAuthor(auth)
            .SetDescription(" ")
            .SetName(" ")
            .SetContent(" ")
            .Build();
        Subject c = new SubjectBuilder()
            .SetAuthor(auth)
            .SetName(" ")
            .SetFormat("зачет")
            .SetLabs([a, a])
            .SetLectures([b])
            .SetPoints(66)
            .Build();
        Subject c2 = c.Clone();
        Assert.True(c2.Based == c.Id);
    }

    [Fact]
    public void TryCreateSubject()
    {
        var auth = new User("s");
        var build = new Builder();
        var rep = new Repository();
        var dir = new Director(build, auth, rep);
        Assert.Throws<Exception>(() => dir.ConstructEducationalProgram());
    }
}