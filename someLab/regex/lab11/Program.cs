using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialValue = "";
            var _path = @"C:\Users\user\Desktop\read.txt";
            using (var streamReader = new StreamReader(_path, true))
            {
                initialValue = streamReader.ReadToEnd();
            }

            var regex = new Regex(@"(?<IPAddress>\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b)");
            MatchCollection matches = regex.Matches(initialValue);


            Console.WriteLine("IP addresses Founded 0 - 255");
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups["IPAddress"].Value);
                }
            }
            Thread.Sleep(2000);

            var regexDate = new Regex(@"(?<date>(((0[1-9]|[12][0-9]|3[01])([-./])(0[13578]|10|12)([-./])(\d{4}))|(([0][1-9]|[12][0-9]|30)([-./])(0[469]|11)([-./])(\d{4}))|((0[1-9]|1[0-9]|2[0-8])([-./])(02)([-./])(\d{4}))|((29)(\.|-|\/)(02)([-./])([02468][048]00))|((29)([-./])(02)([-./])([13579][26]00))|((29)([-./])(02)([-./])([0-9][0-9][0][48]))|((29)([-./])(02)([-./])([0-9][0-9][2468][048]))|((29)([-./])(02)([-./])([0-9][0-9][13579][26]))))");
            MatchCollection matchesDate = regexDate.Matches(initialValue);
            
            Console.WriteLine("Date founded");
            if (matchesDate.Count > 0)
            {
                foreach (Match match in matchesDate)
                {
                    Console.WriteLine(match.Groups["date"].Value);
                }

                return;
            }

            Console.WriteLine("Not Found");

        }
    }
}
