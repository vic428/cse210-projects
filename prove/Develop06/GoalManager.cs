using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    protected List<Goal> _goals = new List<Goal>();
    protected int _score = 0;

    public GoalManager() { }

    public void Start()
    {
        Console.WriteLine("");
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("");
            Console.WriteLine($"Your current score is: {_score}");
            Console.WriteLine("");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }


        Console.WriteLine("The goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i]}");
        }

    }

    public void ListGoalNames()
    {
        Console.WriteLine("Current Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            foreach (Goal goal in _goals)
            {
                string checkBox = goal.IsComplete() ? "[X]" : "[ ]"; // Display checkbox based on completion status
                Console.WriteLine($"{checkBox} {goal.GetDetailsString()}");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void CreateNewGoal()
    {
        Console.WriteLine("");
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter the name for the goal: ");
        string shortName = Console.ReadLine();

        Console.Write("Enter a description for the goal: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            SimpleGoal goal = new SimpleGoal(shortName, description, points);
            _goals.Add(goal);
            Console.WriteLine("");
            Console.WriteLine("Goal created successfully!");
        }
        else if (choice == "2")
        {
            EternalGoal goal = new EternalGoal(shortName, description, points);
            _goals.Add(goal);
            Console.WriteLine("");
            Console.WriteLine("Goal created successfully!");
        }
        else if (choice == "3")
        {
            Console.Write("Enter the target number of completions: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            ChecklistGoal goal = new ChecklistGoal(shortName, description, points, target, bonusPoints);
            _goals.Add(goal);
            Console.WriteLine("");
            Console.WriteLine("Goal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid choice for goal type.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                string checkBox = goal.IsComplete() ? "[X]" : "[ ]"; // Display checkbox based on completion status
                outputFile.WriteLine($"{checkBox}:{goal.GetStringRepresentation()}");
            }
        }
        Console.WriteLine("The goals have been saved.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            using (StreamReader inputFile = new StreamReader(filename))
            {
                _score = int.Parse(inputFile.ReadLine());
                while (!inputFile.EndOfStream)
                {
                    string goalData = inputFile.ReadLine();
                    string[] parts = goalData.Split(':');

                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Error: Unable to parse goal data, skipping line.");
                        continue;
                    }

                    string goalType = parts[0];

                    Goal goal = null;

                    if (goalType == "SimpleGoal")
                    {
                        goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    }
                    else if (goalType == "EternalGoal")
                    {
                        goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                    }

                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("The goals have been loaded.");
        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
        }
    }


    public void RecordEvent()
    {
        Console.WriteLine("The goals are: ");
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are No goals available to record events.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("State the goal you accomplished? ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1];
            selectedGoal.RecordEvent();

            int pointsEarned = selectedGoal.GetPoints();

            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");

            // If the goal is a checklist goal, add bonus points 
            if (selectedGoal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.IsComplete())
                {
                    int bonusPoints = checklistGoal.GetBonusPoints();
                    _score += bonusPoints;
                    Console.WriteLine(" ");
                    Console.WriteLine($"Congratulations! You've completed the checklist goal and have earned an additional {bonusPoints} bonus points!");
                }
                Console.WriteLine($"Completed: {checklistGoal.GetCurrentCount()}/{checklistGoal.GetTarget()}"); //show progress of checklist goal
            }

            Console.WriteLine("Event recorded successfully!");

        }
        else
        {
            Console.WriteLine("Invalid goal index no.");
        }
    }
}
