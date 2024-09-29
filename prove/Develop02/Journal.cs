using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries;  // List to store journal entries

    // Constructor to initialize the list
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Method to add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);  // Add the new entry to the list
        Console.WriteLine("Entry added!\n");
    }

    // Method to display all journal entries
    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("Journal Entries:\n");
        foreach (var entry in _entries)
        {
            entry.Display();  // Use the Entry's Display method to print the entry
        }
    }

    // Method to save all journal entries to a file
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());  // Write the entry to the file in a format
                writer.WriteLine("===ENTRY===");  // Separator between entries
            }
        }
        Console.WriteLine($"Entries saved to {file}");
    }

    // Method to load journal entries from a file
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();  // Clear the current entries before loading

        List<string> entryData = new List<string>();  // Temporary list to store each entry's data
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                if (line == "===ENTRY===")
                {
                    // If we reach the entry separator, process the stored data as a new entry
                    if (entryData.Count >= 3)
                    {
                        Entry entry = Entry.FromFileFormat(entryData.ToArray());  // Create entry from file data
                        _entries.Add(entry);  // Add entry to the journal list
                        entryData.Clear();  // Clear the entry data for the next one
                    }
                }
                else
                {
                    // Add the line to the current entry's data
                    entryData.Add(line);
                }
            }

            // Handle the last entry if there’s no final "===ENTRY===" after the last entry
            if (entryData.Count >= 3)
            {
                Entry entry = Entry.FromFileFormat(entryData.ToArray());
                _entries.Add(entry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading from file: " + ex.Message);
        }

        Console.WriteLine($"Entries loaded from {file}");
    }
}