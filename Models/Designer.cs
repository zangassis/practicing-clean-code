namespace PracticingCleanCode.Models;

public class Designer : Employee
{
    public override void Work()
    {
        Console.WriteLine($"{Name} is designing interfaces.");
    }
}