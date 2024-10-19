using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Prototypes;

public class SubjPrototype : IPrototype<Subject>
{
    public Subject Clone(Subject based)
    {
        var lab = new List<Labs>();
        var lec = new List<LectureMaterials>();
        var lp = new LabPrototype();
        var lecp = new LecturePrototype();

        foreach (Labs i in based.Labs)
        {
            Labs tmp = lp.Clone(i);
            lab.Add(tmp);
        }

        foreach (LectureMaterials i in based.Lectures)
        {
            LectureMaterials tmp = lecp.Clone(i);
            lec.Add(tmp);
        }

        if (based.Format == "экзамен")
        {
            return new Subject(
                based.Author,
                based.Name,
                lab,
                lec,
                based.Format,
                based.ExamPoints,
                based.Id);
        }

        return new Subject(
            based.Author,
            based.Name,
            lab,
            lec,
            based.Format,
            based.MinPoints,
            based.Id);
    }
}