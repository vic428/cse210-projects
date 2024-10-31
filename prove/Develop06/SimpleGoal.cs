using System;

public class SimpleGoal : Goal
{
    private bool _isCompleted = false;
    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {

    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override string GetDetailsString()
    {
        return $"SimpleGoal: {_shortName} Description: {_description} ---({_points} points awarded.)";

    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal: {_shortName}: {_description}: {_points}";
    }
}