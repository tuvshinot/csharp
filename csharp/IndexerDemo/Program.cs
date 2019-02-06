using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerDemo
{
    public class HttpCookie
    {
        /// Dictionary
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public HttpCookie()
        {

        }

        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var cookie = new HttpCookie();
            cookie["name"] = "Tuvshin";


        }
    }
}
