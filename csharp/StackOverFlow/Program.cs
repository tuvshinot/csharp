using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow
{
    public class Post
    {
        private string _title;
        private string _description;
        private DateTime _created;
        private bool _upVote;

        public string Title
        {

            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {

            get { return _description; }
            set { _description = value; }
        }

        private DateTime Created
        {
            get { return _created; }
        }


        public Post()
        {
            _created = DateTime.Today;
        }

        public void UpVote()
        {
            _upVote = true;
        }

        public void DownVote()
        {
            _upVote = false;
        }

        public string CurrentVote()
        {
            var result = "";
            if (_upVote)
                result += "Post is up voted!";
            else
                result += "Post is Down Voted!";

            return result;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var post = new Post
            {
                Title = "My OS i Created!",
                Description = "I Created My OS!"
            };

            post.UpVote();
            post.DownVote();
            Console.WriteLine(post.Title + " : " + post.CurrentVote());
        }
    }
}
