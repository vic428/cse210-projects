using System;

public class Program
{
    public static void Main()
    {
        GoalManager manager = new GoalManager();
        manager.Start();

        // Create goals and add them to the Goal manager
        Goal simpleGoal = new SimpleGoal("Read Book", "Read the entire book", 50);
        Goal checklistGoal = new ChecklistGoal("Complete Course", "Finish all modules", 20, 5, 50);
        Goal eternalGoal = new EternalGoal("Exercise Daily", "Exercise every day", 10);

        manager.CreateGoal(simpleGoal);
        manager.CreateGoal(checklistGoal);
        manager.CreateGoal(eternalGoal);


        // Display set goals
        manager.ListGoalNames();
        manager.ListGoalDetails();

        // Record events
        simpleGoal.RecordEvent();
        eternalGoal.RecordEvent();
        checklistGoal.RecordEvent();

        // Update player score and show information
        manager.DisplayPlayerInfo();
    }
}
