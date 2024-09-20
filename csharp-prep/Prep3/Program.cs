using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {


        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        int randGuess = 0;
        int guessCount = 0;

        //Keep asking for guesses until you get the correct number guessed
        while (randGuess != number)
        {
            Console.Write("What is your guess? ");
            randGuess = int.Parse(Console.ReadLine());
            guessCount++;

            if (number > randGuess)
            {
                Console.WriteLine("Higher");
            }
            else if (number < randGuess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it! and it took {guessCount} guesses.");
            }
        }

        Console.WriteLine("Game over.");


    }
}