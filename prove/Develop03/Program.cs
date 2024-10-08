using System;
using System.IO;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {

        // Create a reference for the scripture (e.g., John 3:16)
        var reference = new Reference("John", 3, 16);

        //scripture text
        string text = "For  God  so  loved the world that He gave His only begotten Son, that whosoever believes in Him shall not perish but have everlasting life.";


        // Create the Scripture object
        Scripture scripture = new(reference, text);

        // Main game loop
        while (true)
        {
            Console.Clear(); // Clear the console for better readability on each iteration
            reference.Display(); //Display the scriptural reference. 
            scripture.Display(); // Display the current state of the scripture

            // Check if the scripture is completely hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Well done!");
                break; // Exit the loop if all words are hidden
            }

            // Prompt the user for input
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to end the game.");
            string input = Console.ReadLine();

            // Exit the game if the user types 'quit'
            if (input.ToLower() == "quit")
            {
                break;
            }


            // Hide random words (you can adjust the number of words to hide each time)
            scripture.HideRandomWords(4); // Hides 3 word per press of Enter

            Console.WriteLine("Thank you for playing!");

        }
    }

}