using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventAndDelegateDemo
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    // delegate and event
    public class Video
    {
        public string Title { get; set; }
    }

    public class VideoEncoder
    {
        public string EncoderDetail => "Video encoding class";

        // 1 - define delegate
        // 2 - Event based on that delegate
        // 3 - raise the event

        // instead of that two line
        /*public delegate void VideoEncodedEventHandler(object source, VideoEventArgs e);
        public event VideoEncodedEventHandler VideoEncoded;*/

        public event EventHandler<VideoEventArgs> VideoEncoded; 


        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);
            OnVideoCoded(video);
        }

        protected virtual void OnVideoCoded(Video video)
        {
            if(VideoEncoded != null)
                VideoEncoded.Invoke(this, new VideoEventArgs(){Video = video});
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video()
            {
                Title = "Video 1 "
            };

            var encoder = new VideoEncoder(); // publisher
            var mailservice = new MailService(); // subscriber
            var messageService = new MessageService(); // subscriber

            encoder.VideoEncoded += mailservice.OnVideoEncoded;
            encoder.VideoEncoded += messageService.OnVideoEncoded;

            encoder.Encode(video);
        }
    }

    // subscriber
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Mail Service : Mail service sending a email " + e.Video.Title);
        }
    }

    // subscriber
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Message Service : Message service sending a text sms " + e.Video.Title);
        }
    }
}
