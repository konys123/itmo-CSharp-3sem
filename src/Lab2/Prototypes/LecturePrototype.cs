using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Prototypes;

public class LecturePrototype : IPrototype<LectureMaterials>
{
    public LectureMaterials Clone(LectureMaterials based)
    {
        return new LectureMaterials(based.Author, based.Name, based.Description, based.Content, based.Id);
    }
}