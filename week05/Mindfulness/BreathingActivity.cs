using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            int remainingInSession = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            int inhaleSeconds = Math.Min(4, remainingInSession);
            if (inhaleSeconds <= 0)
            {
                break;
            }

            Console.Write("\nBreathe in... ");
            ShowCountdown(inhaleSeconds);

            remainingInSession = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            int exhaleSeconds = Math.Min(6, remainingInSession);
            if (exhaleSeconds <= 0)
            {
                break;
            }

            Console.Write("\nBreathe out... ");
            ShowCountdown(exhaleSeconds);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
