using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public int GetWordCount()
    {
        if (string.IsNullOrWhiteSpace(_entryText))
        {
            return 0;
        }

        string[] words = _entryText.Split(new[] { ' ', '\t', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine($"Word Count: {GetWordCount()}");
        Console.WriteLine();
    }
}
