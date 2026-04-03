using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity Added:
        // 1) Session stats are tracked and can be viewed from the menu.
        // 2) Reflection/listing prompts and questions are not repeated until all are used once.
        Dictionary<string, int> activityLog = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflecting", 0 },
            { "Listing", 0 }
        };

        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View session stats");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    activityLog["Breathing"]++;
                    break;

                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    activityLog["Reflecting"]++;
                    break;

                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    activityLog["Listing"]++;
                    break;

                case "4":
                    Console.WriteLine("Session Stats:");
                    Console.WriteLine($"  Breathing activities: {activityLog["Breathing"]}");
                    Console.WriteLine($"  Reflecting activities: {activityLog["Reflecting"]}");
                    Console.WriteLine($"  Listing activities: {activityLog["Listing"]}");
                    Console.Write("Press Enter to return to the menu...");
                    Console.ReadLine();
                    break;

                case "5":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}