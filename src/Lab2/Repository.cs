using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Repository
{
    public IEnumerable<Labs> LabsList { get; set; } = new List<Labs>();

    public IEnumerable<LectureMaterials> LectureMaterialsList { get; set; } = new List<LectureMaterials>();

    public IEnumerable<EducationalProgram> EducationalProgramsList { get; set; } = new List<EducationalProgram>();

    public IEnumerable<Subject> SubjectsList { get; set; } = new List<Subject>();

    public Labs SearchLabs(string name)
    {
        foreach (Labs lab in LabsList)
        {
            if (lab.Name == name)
            {
                return lab;
            }
        }

        throw new Exception();
    }

    public LectureMaterials SearchLectures(string name)
    {
        foreach (LectureMaterials lectures in LectureMaterialsList)
        {
            if (lectures.Name == name)
            {
                return lectures;
            }
        }

        throw new Exception();
    }

    public Subject SearchSubjects(string name)
    {
        foreach (Subject subject in SubjectsList)
        {
            if (subject.Name == name)
            {
                return subject;
            }
        }

        throw new Exception();
    }

    public EducationalProgram SearchEducationalProgram(string name)
    {
        foreach (EducationalProgram educationalProgram in EducationalProgramsList)
        {
            if (educationalProgram.Name == name)
            {
                return educationalProgram;
            }
        }

        throw new Exception();
    }
}