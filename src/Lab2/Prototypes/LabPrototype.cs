using Itmo.ObjectOrientedProgramming.Lab2.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Prototypes;

public class LabPrototype : IPrototype<Labs>
{
    public Labs Clone(Labs based)
    {
        return new Labs(based.Author, based.Name, based.Description, based.EvaluationCriteria, based.MaximumScore, based.Id);
    }
}