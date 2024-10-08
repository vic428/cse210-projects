using System;
using System.Collections.Generic;
using System.IO;

public class Word
{
    public string _text;
    public bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;  //Word is not hidden by default
    }


    public void Hide()
    {
        _isHidden = true;  // Hide the world (set _isHidden to true)
    }

    public void Show()
    {
        _isHidden = false;

    }

    public bool IsHidden()  //check if the word is Hidden
    {
        return _isHidden;
    }

    public void Display()    // display a placeholder for hidden words
    {
        if (_isHidden)
        {
            Console.WriteLine("____");
        }
        else
        {
            Console.Write($"{_text}");
        }
    }
}