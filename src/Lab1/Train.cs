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

    private float Mass { get; set; }

    private float Speed { get; set; }

    private float Acceleration { get; set; }

    private float MaximumForce { get; set; }

    public bool ApplicationOfforce(float force)
    {
        if (force <= MaximumForce)
        {
            Acceleration = force / Mass;
            return true;
        }

        return false;
    }

    public float GetSpeed() => Speed;

    public void TimeCalculation(float accuracy) => TravelTime += accuracy;

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