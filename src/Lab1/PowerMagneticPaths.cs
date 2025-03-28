namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PowerMagneticPaths : IRouteSection
{
    public PowerMagneticPaths(float distance, float force)
    {
        Distance = distance;
        Force = force;
    }

    private float Distance { get; set; }

    private float Force { get; }

    public bool TryToPass(Train train, float accuracy)
    {
        if (!train.ApplicationOfForce(Force))
        {
            return false;
        }

        while (Distance > 0)
        {
            train.SpeedCalculation(accuracy);
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