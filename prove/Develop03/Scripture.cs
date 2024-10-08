using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference; // The reference object (e.g., John 3:16)
    private List<Word> _words;    // A list of words in the scripture

    // Constructor: Initialize with a reference and scripture text
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList(); // Split the text into words and create a list of Word objects
    }

    // Method to hide a given number of random words
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        // Get a list of words that are currently visible (not hidden)
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // If there are fewer visible words than the number requested to hide, just hide all visible words
        numberToHide = Math.Min(numberToHide, visibleWords.Count);

        // Hide random words
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(visibleWords.Count); // Get a random index
            visibleWords[index].Hide(); // Hide the word
            visibleWords.RemoveAt(index); // Remove it from the list to avoid hiding it again
        }
    }

    // Display the scripture with hidden words (displayed as underscores)
    public void Display()
    {
        // Display the scripture reference (e.g., "John 3:16")
        Console.WriteLine(_reference.ToString());

        // Display the scripture words
        foreach (var word in _words)
        {
            word.Display(); // Displays either the word or underscores if hidden
        }

        Console.WriteLine(); // Add a newline after the scripture display
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}

