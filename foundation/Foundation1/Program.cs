using System;

class Program
{
    static void Main(string[] args)
    {
        //create a list to store the videos
        List<Video> videos = new List<Video>();

        //creatre videos and add comments
        Video video1 = new Video("Abstraction in C#", "James Miller", 300);
        video1.AddComment(new Comment("Bob", "Very informative, thanks!"));
        video1.AddComment(new Comment("Bob", "Very informative, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot."));
        videos.Add(video1);

        Video video2 = new Video("Understanding OOP", "Jane Smith", 450);
        video2.AddComment(new Comment("David", "Nice explanation!"));
        video2.AddComment(new Comment("Emma", "Could you explain polymorphism?"));
        videos.Add(video2);

        Video video3 = new Video("Advanced C# Techniques", "Mike Brown", 600);
        video3.AddComment(new Comment("Olivia", "This is very advanced!"));
        video3.AddComment(new Comment("Liam", "Helpful for my project."));
        video3.AddComment(new Comment("Sophia", "Loved the examples."));
        videos.Add(video3);

        //Display information about each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line for separation
        }



    }
}

