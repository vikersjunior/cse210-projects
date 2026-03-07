using System;

class Program
{
    static void Main(string[] args)
    {
        // Exercise 1: Variables, Input, and Output
        // Ask user for their name
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        // Ask user for their favorite number
        Console.Write("What is your favorite number? ");
        string numberInput = Console.ReadLine();
        int number = int.Parse(numberInput);

        // Calculate number plus 1
        int plusOne = number + 1;

        // Calculate number multiplied by 2
        int timesTwo = number * 2;

        // Calculate number squared
        int squared = number * number;

        // Display results
        Console.WriteLine($"Your name is {name}");
        Console.WriteLine($"Your favorite number is {number}");
        Console.WriteLine($"{number} plus 1 is {plusOne}");
        Console.WriteLine($"{number} times 2 is {timesTwo}");
        Console.WriteLine($"{number} squared is {squared}");
    }
}