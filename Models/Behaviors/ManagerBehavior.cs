namespace PracticingCleanCode.Models.Behaviors;

public class ManagerBehavior : IEmployeeBehavior
{
    public void Work()
    {
        Console.WriteLine("The manager is managing projects.");
    }
}