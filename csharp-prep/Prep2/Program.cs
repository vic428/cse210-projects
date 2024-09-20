using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your current percentage? ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);

        string letter = "";

        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "C";
        }
        else if (number >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = number % 10;
        string sign = "";

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }


        Console.WriteLine($"Your grade is {letter} {sign}");

        if (number >= 70)
        {
            Console.WriteLine("Congratulations you passed the course and can now register for the next semester");
        }
        else
        {
            Console.WriteLine("Thank you for your efforts this semester, unfortunately you failed the course. Kindly re-register this course.");
        }


    }
}