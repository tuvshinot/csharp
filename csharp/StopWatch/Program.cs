using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StopWatch
{
    public class Stopwatch
    {
        private DateTime _starting;
        private DateTime _stoping;
        private TimeSpan _duration;
        private bool running;

        public int Duration
        {
            get
            {
                return _duration.Seconds;
            }
        }

        public void Start()
        {
            if (running)
                throw new InvalidCastException("Triggered Twice!");

            running = true;
            _starting = DateTime.Now;
        }

        public void Stop()
        {
            _stoping = DateTime.Now;
            _duration = _stoping - _starting;
            running = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var time = new Stopwatch();

            time.Start();
            Thread.Sleep(5000); // we need to give me to go run!
            time.Stop();

            Console.WriteLine(time.Duration);
        }
    }
}
