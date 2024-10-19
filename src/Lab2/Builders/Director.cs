using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class Director
{
    public Builder Builder { get; set; }

    public User Auth { get; set; }

    public Director(Builder builder, User auth, Repository repository)
    {
        Builder = builder;
        Auth = auth;
        Repository = repository;
    }

    public EducationalProgram ConstructEducationalProgram()
    {
        IEnumerable<Labs> a = Builder.BuildLabsList(Auth, Repository);
        IEnumerable<LectureMaterials> b = Builder.BuildLecturesList(Auth, Repository);
        IEnumerable<Subject> c = Builder.BuildSubjectList(Auth, Repository, a, b);
        EducationalProgram d = Builder.BuildEducationalProgram(c, Auth, Repository);
        return d;
    }

    public Repository Repository { get; set; }
}