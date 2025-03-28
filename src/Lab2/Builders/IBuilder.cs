using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public interface IBuilder
{
    public IEnumerable<Labs> BuildLabsList(User auth, Repository repository);

    public IEnumerable<LectureMaterials> BuildLecturesList(User auth, Repository repository);

    public IEnumerable<Subject> BuildSubjectList(
        User auth,
        Repository repository,
        IEnumerable<Labs> labs,
        IEnumerable<LectureMaterials> lectures);

    public EducationalProgram BuildEducationalProgram(IEnumerable<Subject> subjects, User auth, Repository repository);
}