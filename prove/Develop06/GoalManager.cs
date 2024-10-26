using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        Console.WriteLine("Goal Manager started.");
        //  initialize goals here 
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
        Console.WriteLine($"{goal.GetStringRepresentation()} added.");
    }

    public void RecordEvent()
    {
        foreach (var goal in _goals)
        {
            goal.RecordEvent();
            if (goal.IsComplete())
            {
                _score += goal.Points;
            }
        }
    }

    public void SaveGoals()
    {
        // Implement saving to file
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        // Implement loading from file
        Console.WriteLine("Goals loaded.");
    }
}
