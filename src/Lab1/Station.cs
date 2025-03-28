namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station : IRouteSection
{
    public Station(int numberOfPeople, int speedLimit)
    {
        NumberOfPeople = numberOfPeople;
        SpeedLimit = speedLimit;
    }

    private float NumberOfPeople { get; set; }

    private float SpeedLimit { get; }

    public bool TryToPass(Train train, float accuracy)
    {
        if (train.Speed <= SpeedLimit)
        {
            while (NumberOfPeople > 0)
            {
                NumberOfPeople -= train.PeopleCalculation(accuracy);
            }

            return true;
        }

        return false;
    }
}