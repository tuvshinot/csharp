using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustumExceptionHandling
{
    public class YouTubeException : Exception
    {
        public string MessageCopy { get; set; }

        public YouTubeException(string message, Exception innerException)
            :base(message, innerException)
        {
            MessageCopy = message;

        }

        ~YouTubeException()
        {
             
        }
    }

    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // accessing youtube webservice
                // Read date
                // create list of video

                throw new Exception("oops some low level youtube error"); // make it throw exception and catch block takes it--it is inner ex
            }
            catch (Exception e)
            {
                // log
                throw new YouTubeException("Could not fetch the videos from youtube", e);
            }

            return new List<Video>();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var api = new YouTubeApi();
                var videos = api.GetVideos("bigdawtv");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
