//This is the base Activity class 
using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime date;
    private int minutes;

    protected Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public DateTime Date => date;
    public int Minutes => minutes;

    //methods for derived classes to ovveride 
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    //GetSummary method to display information on each activity
    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy} {GetType().Name} ({minutes} min) - Distance: {GetDistance():F2} km, " +
               $"Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}