using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# for Beginners in 20 Minutes", "CodeClass", 1200);
        video1.AddComment(new Comment("Alex", "This explanation was so clear."));
        video1.AddComment(new Comment("Clement", "I finally understand classes now."));
        video1.AddComment(new Comment("Jordan", "Could you do one on inheritance next?"));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Study Habits That Actually Work", "CampusCoach", 845);
        video2.AddComment(new Comment("Mina", "Habit #3 made a huge difference for me."));
        video2.AddComment(new Comment("Ethan", "Great tips, short and practical."));
        video2.AddComment(new Comment("Joel", "Would love a part 2 for exam week."));
        videos.Add(video2);

        Video video3 = new Video("How to Meal Prep on a Budget", "SmartKitchen", 960);
        video3.AddComment(new Comment("Sam", "The grocery breakdown was super helpful."));
        video3.AddComment(new Comment("Riley", "Tried the rice bowl recipe, amazing."));
        video3.AddComment(new Comment("Noah", "Please share a vegetarian version too."));
        videos.Add(video3);

        Video video4 = new Video("Morning Stretch Routine for Desk Workers", "MoveDaily", 540);
        video4.AddComment(new Comment("Kim", "My back feels better already."));
        video4.AddComment(new Comment("Omar", "Perfect routine before work."));
        video4.AddComment(new Comment("Tara", "Simple and easy to follow."));
        video4.AddComment(new Comment("Ben", "Can you make a 5-minute evening routine?"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLengthInSeconds()}");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}