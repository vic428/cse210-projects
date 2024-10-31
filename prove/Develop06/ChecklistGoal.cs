using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;

    private int _bonusPoints;



    public ChecklistGoal(string shortName, string description, int amountCompleted, int target, int points, int bonusPoints) : base(shortName, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal(string shortName, string description,int target, int points, int bonusPoints) : base(shortName, description, points)
     {
        _target = target;
        _bonusPoints = bonusPoints;
        _amountCompleted = 0;
     }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }


    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public int GetCurrentCount()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    public override string GetStringRepresentation()
    {
        return  $"ChecklistGoal: {_shortName}: {_description}: {_amountCompleted}: {_target}: {_points}: {_bonusPoints}";
    }

    public override string GetDetailsString()
    {
        return $"ChecklistGoal: {_shortName}: {_description}:  Currently completed, {_amountCompleted}/{_target}";
    }

}