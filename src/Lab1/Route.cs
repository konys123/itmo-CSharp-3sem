namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    public Route(IEnumerable<IRouteSection> rout, float accuracy, Train train, float speedLimit)
    {
        _rout = rout.ToList();
        Accuracy = accuracy;
        _train = train;
        SpeedLimit = speedLimit;
    }

    private float SpeedLimit { get; }

    private readonly List<IRouteSection> _rout;

    private readonly Train _train;

    private float Accuracy { get; }

    public bool TryToComplete()
    {
        foreach (IRouteSection routeSection in _rout)
        {
            if (!routeSection.TryToPass(_train, Accuracy))
            {
                _train.Status();
                return false;
            }
        }

        if (_train.Speed > SpeedLimit)
        {
            return false;
        }

        return true;
    }
}