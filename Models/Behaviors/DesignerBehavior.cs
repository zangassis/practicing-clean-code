namespace PracticingCleanCode.Models.Behaviors;

public class DesignerBehavior : IEmployeeBehavior
{
    public void Work()
    {
        Console.WriteLine("The designer is creating designs.");
    }
}