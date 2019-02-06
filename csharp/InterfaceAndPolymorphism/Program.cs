using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterfaceAndPolymorphism
{
    public class VideoEncoder
    {
        private readonly IList<INotificationChannel> _notificationChannels;

        public VideoEncoder()
        {
            _notificationChannels = new List<INotificationChannel>();
        }

        public void Encode(Video video)
        {
            // video encoding logic
            foreach (var channel in _notificationChannels)
            {
                channel.send(new Message());
            }
        }

        public void RegisterINotificationChannel(INotificationChannel channel)
        {
            _notificationChannels.Add(channel);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var videoEncoder = new VideoEncoder();

            videoEncoder.RegisterINotificationChannel(new MailNotificationChannel());
            videoEncoder.RegisterINotificationChannel(new SmsNotificationChannel());
            videoEncoder.Encode(new Video());
        }
    }
}
