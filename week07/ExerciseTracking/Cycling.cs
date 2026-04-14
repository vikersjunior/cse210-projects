using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * GetMinutes() / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        if (_speed == 0)
        {
            return 0;
        }

        return 60 / _speed;
    }

    public override string GetActivityName()
    {
        return "Cycling";
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