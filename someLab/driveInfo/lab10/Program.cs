using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static double GetDirectorySize(string path)
        {
            // 1.
            // Get array of all file names.
            string[] allFiles = Directory.GetFiles(path, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            double size = 0;
            foreach (string file in allFiles)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(file);
                size += info.Length;
            }
            // 4.
            // Return total size
            return size / 1000000;
        }

        static void Main(string[] args)
        {
            var fileName = @"c:\Users\user\Desktop\log.txt";
            using (var writer = new StreamWriter(fileName, true)) 
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo d in allDrives)
                {
                    int above500Mb = 0;
                    if (d.IsReady)
                    {
                        var allDir = d.RootDirectory.GetDirectories();
                        foreach (var dir in allDir)
                        {
                            double size = 0;
                            try
                            {
                                size = GetDirectorySize(dir.FullName);

                            }
                            catch (Exception e)
                            {
                                size = 0;
                                continue;
                            }

                            if (size > 500.0)
                            {
                                above500Mb++;
                            }
                        }
                    }

                    writer.WriteLine("-----------------------------------");
                    writer.WriteLine("Drive {0}", d.Name);
                    writer.WriteLine("  Drive type: {0}", d.DriveType);
                    writer.WriteLine("Directories Above 500 Mb Directories : " + above500Mb);
                    if (d.IsReady == true)
                    {
                        writer.WriteLine("  Volume label: {0}", d.VolumeLabel);
                        writer.WriteLine("  File system: {0}", d.DriveFormat);
                        writer.WriteLine(
                            "  Available space to current user:{0, 15} megabytes",
                            d.AvailableFreeSpace / 1000000);

                        writer.WriteLine(
                            "  Total available space:          {0, 15} megabytes",
                            d.TotalFreeSpace / 1000000);

                        writer.WriteLine(
                            "  Total size of drive:            {0, 15} megabytes ",
                            d.TotalSize / 1000000);
                    }
                    writer.WriteLine("-----------------------------------");
                }
            }
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Successfully : ");
            Console.WriteLine("Check y/n ?");
            var ans = Console.ReadLine();
            if (ans == "y") Process.Start(fileName);


        }


    }
}
