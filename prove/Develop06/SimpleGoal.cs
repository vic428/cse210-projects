public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"{_shortName} has been completed! You earned {_points} points.");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} - Points: {_points}";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - {(IsComplete() ? "Complete" : "Incomplete")}";
    }
}
