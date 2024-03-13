namespace PracticingCleanCode.Models.Behaviors;

public class DeveloperBehavior : IEmployeeBehavior
{
    public void Work()
    {
        Console.WriteLine("The developer is writing code.");
    }
}
