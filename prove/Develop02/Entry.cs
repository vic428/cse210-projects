public class Entry
{
    public string _date;   //Storws the date of the entry 
    public string _promptText;    //Stores the prompt used for the entry 
    public string _entryText;    //stores the actual journal entry text

    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Set the date to the current date and time
        _promptText = promptText;
        _entryText = entryText;
    }

    // Menthod to display the entry details 
    public void Display()
    {
        Console.WriteLine($"{_promptText}");
        Console.WriteLine($"{_date} {_entryText}");
    }

    //Method to convert the entry into a File format 
    public string ToFileFormat() => $"{_date}\n{_promptText}\n{_entryText.Replace("\n", "\\n")}";

    //Static Method to load an entry from file format
    public static Entry FromFileFormat(string[] data)
    {
        string date = data[0];
        string promptText = data[1];
        string entryText = data[2].Replace("\\n", "\n");
        Entry entry = new(promptText, entryText);
        entry._date = date; // Set the date from the file
        return entry;

    }

}