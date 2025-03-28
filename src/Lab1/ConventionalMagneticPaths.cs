namespace Itmo.ObjectOrientedProgramming.Lab1;

public class ConventionalMagneticPaths : IRouteSection
{
    public ConventionalMagneticPaths(float distance)
    {
        Distance = distance;
    }

    private float Distance { get; set; }

    public bool TryToPass(Train train, float accuracy)
    {
        train.ApplicationOfForce(0);
        while (Distance > 0)
        {
            float dist = train.DistanceCalculation(accuracy);
            Distance -= dist;
            if (dist <= 0)
            {
                return false;
            }
        }

        return true;
    }
}