using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class Builder : IBuilder
{
    public IEnumerable<Labs> BuildLabsList(User auth, Repository repository)
    {
        Labs lab1 = new LabsBuilder()
            .SetAuthor(auth)
            .SetName("Лабораторная работа 1")
            .SetDescription("Описание лабораторной работы")
            .SetEvaluationCriteria("Критерии оценки")
            .SetMaximumScore(25)
            .Build();

        Labs lab2 = new LabsBuilder()
            .SetAuthor(auth)
            .SetName("Лабораторная работа 2")
            .SetDescription("Описание лабораторной работы")
            .SetEvaluationCriteria("Критерии оценки")
            .SetMaximumScore(25)
            .Build();

        Labs lab3 = new LabsBuilder()
            .SetAuthor(auth)
            .SetName("Лабораторная работа 3")
            .SetDescription("Описание лабораторной работы")
            .SetEvaluationCriteria("Критерии оценки")
            .SetMaximumScore(25)
            .Build();

        var labsList = repository.LabsList.ToList();
        labsList.AddRange(new[] { lab1, lab2, lab3 });
        repository.LabsList = labsList;

        return labsList;
    }

    public IEnumerable<LectureMaterials> BuildLecturesList(User auth, Repository repository)
    {
        LectureMaterials lec1 = new LectureMaterialsBuilder()
            .SetAuthor(auth)
            .SetName("Лекция 1")
            .SetDescription("Описание лабораторной работы")
            .SetContent("Контент")
            .Build();

        LectureMaterials lec2 = new LectureMaterialsBuilder()
            .SetAuthor(auth)
            .SetName("Лекция 2")
            .SetDescription("Описание лабораторной работы")
            .SetContent("Контент")
            .Build();

        var lectureMaterialsList =
            repository.LectureMaterialsList.ToList();
        lectureMaterialsList.AddRange(new[] { lec1, lec2 });
        repository.LectureMaterialsList = lectureMaterialsList;

        return lectureMaterialsList;
    }

    public IEnumerable<Subject> BuildSubjectList(
        User auth,
        Repository repository,
        IEnumerable<Labs> labs,
        IEnumerable<LectureMaterials> lectures)
    {
        Subject sub1 = new SubjectBuilder()
            .SetAuthor(auth)
            .SetName("Прога")
            .SetFormat("зачет")
            .SetLabs(labs)
            .SetLectures(lectures)
            .SetPoints(99)
            .Build();

        Subject sub2 = new SubjectBuilder()
            .SetAuthor(auth)
            .SetName("Алго")
            .SetFormat("экзамен")
            .SetLabs(labs)
            .SetLectures(lectures)
            .SetPoints(20)
            .Build();

        var subjects = repository.SubjectsList.ToList();
        subjects.AddRange(new[] { sub1, sub2 });
        repository.SubjectsList = subjects;

        return subjects;
    }

    public EducationalProgram BuildEducationalProgram(IEnumerable<Subject> subjects, User auth, Repository repository)
    {
        EducationalProgramBuilder ed = new EducationalProgramBuilder()
            .SetAuthor(auth)
            .SetName("is");
        foreach (Subject subject in subjects)
        {
            ed.AddSubject(subject);
            ed.AddFirstSemesterSubject(subject);
            ed.AddSecondSemesterSubject(subject);
        }

        EducationalProgram edProgram = ed.Build();
        var educationalPrograms = repository.EducationalProgramsList.ToList();
        educationalPrograms.Add(edProgram);
        repository.EducationalProgramsList = educationalPrograms;

        return edProgram;
    }
}