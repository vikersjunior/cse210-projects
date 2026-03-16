// Scripture Memorizer – exceeds core requirements in two ways:
//
// 1. Scripture Library: Instead of always showing the same scripture, the program
//    randomly selects one from a built-in library of six well-known scriptures each
//    time it runs, giving the user variety across practice sessions.
//
// 2. Smart Word Hiding: When selecting words to hide, the program
//    only picks from words that are still visible. This guarantees that every Enter
//    press hides exactly 3 NEW words (or however many remain), so no turn is ever
//    wasted re-hiding an already-hidden word.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(
                new Reference("Psalms", 23, 1),
                "The Lord is my shepherd; I shall not want."),
            new Scripture(
                new Reference("2 Timothy", 1, 7),
                "For God hath not given us the spirit of fear; but of power, and of love, and of a sound mind."),
            new Scripture(
                new Reference("Isaiah", 41, 10),
                "Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee; yea, I will uphold thee with the right hand of my righteousness."),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.")
        };

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Great job!");
                break;
            }

            Console.Write("Press Enter to continue, or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}
