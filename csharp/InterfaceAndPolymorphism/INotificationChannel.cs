using System;
using System.Threading;

namespace InterfaceAndPolymorphism
{
    public class MailNotificationChannel : INotificationChannel
    {
        public void send(Message message)
        {
            Console.WriteLine("Sending Mail...");
            Thread.Sleep(5000);
            Console.WriteLine("Mail Sent! ");
        }
    }

    public class SmsNotificationChannel : INotificationChannel
    {
        public void send(Message message)
        {
            Console.WriteLine("Sending SMS...");
            Thread.Sleep(5000);
            Console.WriteLine("Mail SMS! ");
        }
    }

    public interface INotificationChannel
    {
        void send(Message message);
    }
}