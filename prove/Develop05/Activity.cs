abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, String description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);  // Pausing before starting the activity
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You've completed {_name} for {_duration} seconds.");
        ShowSpinner(3);  // Pausing before ending the activity
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in {i} seconds...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\rGo!          ");
    }

    public abstract void Run();
}