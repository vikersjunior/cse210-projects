using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.Clear();
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Good luck on your eternal quest!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }

            if (choice != "6")
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        string rank = GetRankTitle(level);

        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {level} | Rank: {rank}");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine() ?? "";

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        int points = ReadInt("What is the amount of points associated with this goal? ");

        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("Simple goal created.");
        }
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine("Eternal goal created.");
        }
        else if (goalType == "3")
        {
            int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        ListGoalNames();
        int goalNumber = ReadInt("Which goal did you accomplish? ");

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];
        int earnedPoints = selectedGoal.RecordEvent();

        if (earnedPoints > 0)
        {
            _score += earnedPoints;
            Console.WriteLine($"Congratulations! You earned {earnedPoints} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("That goal is already complete, so no additional points were awarded.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split("|");

            if (parts[0] == "Score")
            {
                if (parts.Length > 1 && int.TryParse(parts[1], out int loadedScore))
                {
                    _score = loadedScore;
                }
                continue;
            }

            Goal loadedGoal = CreateGoalFromParts(parts);
            if (loadedGoal != null)
            {
                _goals.Add(loadedGoal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private Goal CreateGoalFromParts(string[] parts)
    {
        if (parts.Length < 4)
        {
            return null;
        }

        string type = parts[0];
        string name = parts[1];
        string description = parts[2];

        if (!int.TryParse(parts[3], out int points))
        {
            return null;
        }

        if (type == "SimpleGoal")
        {
            bool isComplete = false;
            if (parts.Length > 4)
            {
                bool.TryParse(parts[4], out isComplete);
            }

            return new SimpleGoal(name, description, points, isComplete);
        }

        if (type == "EternalGoal")
        {
            return new EternalGoal(name, description, points);
        }

        if (type == "ChecklistGoal")
        {
            if (parts.Length < 7)
            {
                return null;
            }

            if (int.TryParse(parts[4], out int bonus)
                && int.TryParse(parts[5], out int target)
                && int.TryParse(parts[6], out int amountCompleted))
            {
                return new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
            }
        }

        return null;
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid whole number.");
        }
    }

    private string GetRankTitle(int level)
    {
        if (level < 3)
        {
            return "Seeker";
        }

        if (level < 6)
        {
            return "Disciple";
        }

        if (level < 10)
        {
            return "Steadfast";
        }

        return "Eternal Champion";
    }
}
