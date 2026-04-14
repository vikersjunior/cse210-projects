using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        if (GetMinutes() == 0)
        {
            return 0;
        }

        return GetDistance() / GetMinutes() * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();

        if (distance == 0)
        {
            return 0;
        }

        return GetMinutes() / distance;
    }

    public override string GetActivityName()
    {
        return "Swimming";
    }

    public override string GetDistanceUnit()
    {
        return "miles";
    }

    public override string GetSpeedUnit()
    {
        return "mph";
    }

    public override string GetPaceUnit()
    {
        return "mile";
    }
}