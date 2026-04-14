using System;
using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected DateTime GetDate()
    {
        return _date;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public abstract string GetActivityName();

    public abstract string GetDistanceUnit();

    public abstract string GetSpeedUnit();

    public abstract string GetPaceUnit();

    public virtual string GetSummary()
    {
        string date = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        return $"{date} {GetActivityName()} ({_minutes} min)- Distance {FormatNumber(GetDistance())} {GetDistanceUnit()}, Speed {FormatNumber(GetSpeed())} {GetSpeedUnit()}, Pace: {FormatNumber(GetPace())} min per {GetPaceUnit()}";
    }

    protected string FormatNumber(double value)
    {
        return value.ToString("0.0#", CultureInfo.InvariantCulture);
    }
}