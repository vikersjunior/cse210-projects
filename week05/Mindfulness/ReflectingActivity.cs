using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Queue<string> _promptQueue;
    private Queue<string> _questionQueue;
    private Random _random;

    public ReflectingActivity()
        : base(
            "Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _promptQueue = new Queue<string>();
        _questionQueue = new Queue<string>();
        _random = new Random();
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);
        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {GetRandomQuestion()} ");
            ShowSpinner(5);
            Console.WriteLine();
        }

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

    public string GetRandomQuestion()
    {
        if (_questionQueue.Count == 0)
        {
            _questionQueue = BuildShuffledQueue(_questions);
        }

        return _questionQueue.Dequeue();
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
