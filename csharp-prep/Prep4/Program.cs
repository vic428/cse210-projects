using System;
using System.Collections.Generic;
using System.Linq; //required for max computations

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        // Creating an empty list<T> of Integers.
        List<int> numbers = new List<int>();
        int sum = 0; //this variable stores the sum of the numbers entered

        while (true)
        {
            //prompt the user to enter a number 
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            //check if the user entered 0 to stop the loop
            if (num == 0)
            {
                break;
            }
            //Add the number to the list
            numbers.Add(num);
        }
        // Calculate the sum of the numbers 
        foreach (int number in numbers)
        {
            sum += number;
        }


        // Display the numbers entered
        Console.WriteLine(" Enter Number: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        // Display the sum of the numbers
        Console.WriteLine("The sum is: " + sum);

        // Calculate and display the average & Max of the numbers
        if (numbers.Count > 0)
        {
            double average = (double)sum / numbers.Count;
            Console.WriteLine("The average is: " + average);

            // Find the maximum number using Max()
            int maxNumber = numbers.Max();
            Console.WriteLine("The maximum number is: " + maxNumber);
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }

        // Find the smallest positive number
        int? smallestPositive = null;
        foreach (int number in numbers)
        {
            // Check if the number is positive and either the first positive we've found
            // or smaller than the current smallest positive number.
            if (number > 0 && (smallestPositive == null || number < smallestPositive))
            {
                smallestPositive = number;
            }
        }

        if (smallestPositive.HasValue)
        {
            Console.WriteLine("The smallest positive number is: " + smallestPositive);
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        // Sort the list
        numbers.Sort();

        // Display the sorted numbers
        Console.WriteLine("\nThe sorted numbers are:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }


    }
}