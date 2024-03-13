using PracticingCleanCode.Models;

namespace PracticingCleanCode.Services;

public class NotificationService
{
    public void ProcessSendingNotifications(Notification notification)
    {
        if (!string.IsNullOrEmpty(notification.Message))
        {
            notification.SendNotification();
        }
        else
        {
            Console.WriteLine("Notification: No message to send.");
        }
    }

    public void ProcessSendingNotificationsBetter(Notification notification)
    {
        notification.SendNotification();
    }
}