using System;
using System.Collections.Generic;
using System.Linq;

public class Resume
{
    public string _name;

    //initialize list to a new list 
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs: ");

        foreach (Job job in _jobs)
        {
            //Calls the display method for each job
            job.Display();
        }
    }
}