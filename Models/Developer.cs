namespace PracticingCleanCode.Models;

public class Developer : Employee
{
    public override void Work()
    {
        Console.WriteLine($"{Name} is developing code.");
    }
}