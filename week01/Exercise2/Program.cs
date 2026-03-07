using System;

class Program
{
    static void Main(string[] args)
    {
        // Exercise 2: Conditionals
        // Ask user for a number
        Console.Write("What is your number? ");
        string input = Console.ReadLine();
        int number = int.Parse(input);

        // Check if the number is positive, negative, or zero
        if (number > 0)
        {
            Console.WriteLine($"{number} is positive.");
        }
        else if (number < 0)
        {
            Console.WriteLine($"{number} is negative.");
        }
        else
        {
            Console.WriteLine($"{number} is zero.");
        }

        // Check if the number is even or odd
        if (number % 2 == 0)
        {
            Console.WriteLine($"{number} is even.");
        }
        else
        {
            Console.WriteLine($"{number} is odd.");
        }
    }
}