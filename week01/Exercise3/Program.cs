using System;

class Program
{
    static void Main(string[] args)
    {
        // Exercise 3: Loops - Guess My Number
        Random randomGenerator = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            // Loop until user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if user wants to play again
            Console.Write("Do you want to play again? (yes/no) ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes" || response == "y");
        }
    }
}