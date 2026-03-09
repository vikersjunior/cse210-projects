using System;

class Program
{
    static void Main(string[] args)
    {
        // Exercise 1: Variables, Input, and Output
        // Prompt for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display in the format: "Your name is last-name, first-name, last-name."
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}