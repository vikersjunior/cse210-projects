using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private Queue<string> _promptQueue;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _promptQueue = new Queue<string>();
        _random = new Random();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> entries = GetListFromUser();
        _count = entries.Count;

        Console.WriteLine($"\nYou listed {_count} items!");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        if (_promptQueue.Count == 0)
        {
            _promptQueue = BuildShuffledQueue(_prompts);
        }

        return _promptQueue.Dequeue();
    }

    public List<string> GetListFromUser()
    {
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);
        List<string> entries = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                entries.Add(response.Trim());
            }
        }

        return entries;
    }

    private Queue<string> BuildShuffledQueue(List<string> source)
    {
        List<string> copy = new List<string>(source);

        for (int i = copy.Count - 1; i > 0; i--)
        {
            int swapIndex = _random.Next(i + 1);
            string temp = copy[i];
            copy[i] = copy[swapIndex];
            copy[swapIndex] = temp;
        }

        return new Queue<string>(copy);
    }
}
