using PracticigCleanCode.Models;

namespace PracticingCleanCode.Models;

public class Notification
{
    private Guid guid;
    private string v;

    public Guid Id { get; set; }
    public string? EmployeeName { get; set; }
    public NotificationType? NotificationType { get; set; }
    public string Message { get; set; }

    public Notification(Guid id, string employeeName, NotificationType payment)
    {
        Id = id;
        EmployeeName = employeeName;
    }

    public Notification()
    {
    }

    public Notification(Guid guid, string v)
    {
        this.guid = guid;
        this.v = v;
    }

    public void SendNotification()
    {
        //Logic to send notification
    }

    public void SendNotificationBetter()
    {
        if (!string.IsNullOrEmpty(Message))
        {
            //Logic to send notification
        }
        else
        {
            Console.WriteLine("Notification: No message to send.");
        }
    }

}