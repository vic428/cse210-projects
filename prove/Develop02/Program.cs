using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();  // this creates a new Journal instance
        PromptGenerator promptGenerator = new();  //creates an instance of the prompt generator
        string fileName = "journal_entries.txt";
        bool running = true;

        //load existing entries from file 
        // journal.LoadFromFile(fileName);

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save ");
            Console.WriteLine("5. Exit ");
            Console.WriteLine("Choose an option from 1-5: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //Get a random propmt from the user
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine("Prompt: " + randomPrompt);

                    //Get the users response to a random prompt
                    Console.WriteLine("Response: ");
                    string entryText = Console.ReadLine();

                    //create a new Journal Entry with the random prompt and response by the user
                    Entry newEntry = new Entry(randomPrompt, entryText);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    // Display all entries 
                    journal.Display();
                    break;

                case "3":
                    // Load all entries from file
                    journal.LoadFromFile(fileName);
                    break;

                case "4":
                    // Save all entries to file
                    journal.SaveToFile(fileName);
                    break;

                case "5":
                    // Exit program
                    running = false;
                    Console.WriteLine("Exiting the Journal Program");
                    break;

                default:
                    // For invalid inputs
                    Console.WriteLine("Invalid Choice, please select from 1-5: ");
                    break;

            }

        }
    }
}