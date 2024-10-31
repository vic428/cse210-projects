using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of each activity
        Activity running = new Running(new DateTime(2022, 11, 3), 30, 4.8); // Distance in km
        Activity cycling = new Cycling(new DateTime(2022, 11, 3), 30, 20); // Speed in kph
        Activity swimming = new Swimming(new DateTime(2022, 11, 3), 30, 20); // Laps

        // Adding activities to a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Displaying summaries for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

    }
}