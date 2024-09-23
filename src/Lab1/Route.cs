namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    public Route(System.Collections.ObjectModel.Collection<IRouteSection> rout, float accuracy, Train train, float speedLimit)
    {
        _rout = rout;
        Accuracy = accuracy;
        _train = train;
        SpeedLimit = speedLimit;
    }

    private float SpeedLimit { get; set; }

    private readonly System.Collections.ObjectModel.Collection<IRouteSection> _rout;

    private readonly Train _train;

    private float Accuracy { get; set; }

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

        if (_train.GetSpeed() > SpeedLimit)
        {
            _train.Status();
            return false;
        }

        _train.Status();
        return true;
    }
}