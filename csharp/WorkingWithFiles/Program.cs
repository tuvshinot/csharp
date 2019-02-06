using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkingWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fileinfo--instance vs file --static
            var path = @"c:\my.jpg";
            File.Copy(@"c:\my.jpg", @"d:\newmy.jpg", true);// last one is overwrite
            File.Delete(path);


            if (File.Exists(path))
            {
                //to something
            }
            var content = File.ReadAllText(path);

            FileInfo fileInfo = new FileInfo(path);
            fileInfo.CopyTo("...");
            fileInfo.Delete();


            if (fileInfo.Exists)
            {
                //todo
            }



            // DirectoryInfo -- instance vs Directory -- static
            Directory.CreateDirectory(@"c:\folder");
            var files = Directory.GetFiles("..folder location.", "*.exe", SearchOption.AllDirectories);
            foreach(var file in files)
                Console.WriteLine("...");

            Directory.GetDirectories("...");
            Directory.Exists("folderName");

            var directotyInfo = new DirectoryInfo("...folderLocation");





            // if big project just use instance one cuz it u know see udemy!

        }
    }
}
