public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"{_shortName} event recorded! You earned {_points} points.");
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} - Points: {_points} (Eternal)";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - Eternal";
    }
}
