namespace PracticingCleanCode.Models;

public class Manager : Employee
{
    public override void Work()
    {
        Console.WriteLine($"{Name} is managing projects.");
    }
}