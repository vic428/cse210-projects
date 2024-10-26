public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"{_shortName} progress: {_amountCompleted}/{_target}. You earned {_points} points.");

            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Checklist complete! Bonus of {_bonus} points earned!");
            }
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} - Points: {_points} - Target: {_target} - Bonus: {_bonus}";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - Progress: {_amountCompleted}/{_target} - {(IsComplete() ? "Complete" : "Incomplete")}";
    }
}
