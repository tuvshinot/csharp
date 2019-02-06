using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DelagateDemo
{
    public class Photo
    {
        public static Photo Load(string path)
        {

            Console.WriteLine("Photo Loaded!");
            return new Photo();
        }

        public void Save()
        {
            Console.WriteLine("Photo Saved!");
        }

    }

    public class PhotoFilters
    {
        public void ApplyBrigthness(Photo photo)
        {
            Console.WriteLine("Apply Brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply Contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }
    }


    // delegate 
    public class PhotoProcessor
    {
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var process = new PhotoProcessor();
            var filter = new PhotoFilters();


            Action<Photo> filterHandler = filter.ApplyBrigthness;
            filterHandler += filter.Resize;
            // adding my own one
            filterHandler += RemoveRedEye;


            process.Process(@"path", filterHandler);
        }

        /// adding new filter without touching source code
        static void RemoveRedEye(Photo photo)
        {
            Console.WriteLine("Apply remove red eye;");
        }
    }
}
