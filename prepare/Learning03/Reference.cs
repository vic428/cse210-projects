using System;
using System.Collections.Generic;

public class Reference
{
    public string _book;
    public int _chapter;
    public int _verse;
    public int _endVerse;

    //constructor for single verse 
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = -1; // Single verse indicator 
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public void Display()
    {
        if (_endVerse == -1)
        {
            Console.WriteLine(ReferenceSingle(_book, _chapter, _verse));
        }
        else
        {
            Console.WriteLine(ReferenceRange(_book, _chapter, _verse, _endVerse));
        }

    }

    // Static method for single verse reference
    public static string ReferenceSingle(string book, int chapter, int verse)
    {
        return $"{book} {chapter}:{verse}";
    }

    // Static method for verse range reference
    public static string ReferenceRange(string book, int chapter, int startVerse, int endVerse)
    {
        return $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}