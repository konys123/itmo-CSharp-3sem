namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    public Train(float mass, float maximumForce)
    {
        Mass = mass;
        MaximumForce = maximumForce;
    }

    private float TravelTime { get; set; }

    private float DistanceTraveled { get; set; }

    private float Mass { get; }

    private float Acceleration { get; set; }

    private float MaximumForce { get; }

    public bool ApplicationOfForce(float force)
    {
        if (!(force <= MaximumForce)) return false;
        Acceleration = force / Mass;
        return true;
    }

    public void TimeCalculation(float accuracy) => TravelTime += accuracy;

    public float Speed { get; private set; }

    public void SpeedCalculation(float accuracy) => Speed += Acceleration * accuracy;

    public float DistanceCalculation(float accuracy)
    {
        TimeCalculation(accuracy);
        DistanceTraveled += Speed * accuracy;
        return Speed * accuracy;
    }

    public float PeopleCalculation(float accuracy)
    {
        TimeCalculation(accuracy);
        return 10 * accuracy;
    }

    public string Status()
    {
        return $"время в пути: {TravelTime} с \nпройденное расстояние: {DistanceTraveled} м \nскорость: {Speed} м/с";
    }
}