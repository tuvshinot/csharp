using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4MVD
{
    enum Frequency
    {
        Weekly = 1,
        Monthly,
        Yearly
    }

    class Person
    {
        private string _fName;
        private string _lName;
        private DateTime _bDate;

        public string FirstName { get { return _fName; } set { _fName = value; } }
        public string LastName { get { return _lName; } set { _lName = value; } }
        public DateTime BirthDate { get { return _bDate; } set { _bDate = value; } }
        public int BirthYear { get { return _bDate.Year; } set { _bDate = new DateTime(value, _bDate.Month, _bDate.Day); } }

        public Person()
        {
            FirstName = "Jonh";
            LastName = "Barry";
            BirthDate = new DateTime(1998, 3, 19);
        }

        public Person(string FirstName, string LastName, DateTime BirthDate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Last Name: {1} Day of Birth: {2}", FirstName, LastName, BirthDate);
        }

        public virtual string ToShortString()
        {
            return string.Format("Name: {0} LastName: {1}", FirstName, LastName);
        }
    }

    class Article
    {
        public Person Author { get; set; }
        public string ArticleName { get; set; }
        public double ArticleRate { get; set; }

        public Article()
        {
            Author = new Person();
            ArticleName = "New post";
            ArticleRate = 0;
        }

        public Article(Person Author, string ArticleName, double ArticleRate)
        {
            this.Author = Author;
            this.ArticleName = ArticleName;
            this.ArticleRate = ArticleRate;
        }

        public override string ToString()
        {
            return string.Format("Name of Post: {0} Rating: {1} \n\tAbout Author: \n\t{2}", ArticleName, ArticleRate, Author.ToString());
        }
    }

    class Magazine
    {
        private string _magazineName;
        private Frequency _magazineIssue;
        private DateTime _releaseDate;
        private int _circulation;
        private Article[] _articleList;

        public string MagazineName
        {
            get { return _magazineName; }
            set
            {
                if (value != null)
                    _magazineName = value;
                else
                {
                    Console.Write("Enter name of magazine: ");
                    _magazineName = Console.ReadLine();
                }
            }
        }
        public Frequency MagazineIssue
        {
            get { return _magazineIssue; }
            set
            {
                if ((int)value == -1)
                    _magazineIssue = value;
                else
                {
                    Console.WriteLine("Enter Frequency post(weekly, daily etc): ");
                    FreqIndexes();
                }
            }
        }
        public DateTime ReleaseDate { get { return _releaseDate; } set { _releaseDate = value; } }
        public int Circulation { get { return _circulation; } set { _circulation = value; } }
        public Article[] ArticleList { get { return _articleList; } set { _articleList = value; } }

        public double AverageRate
        {
            get
            {
                double result = 0;
                for (int i = 0; i < ArticleList.Length; i++)
                    result += ArticleList[i].ArticleRate;
                return result / _articleList.Length;
            }
        }

        public bool this[Frequency i]
        {
            get
            {
                if (MagazineIssue == i)
                    return true;
                else
                    return false;
            }
        }

        public Magazine()
        {
            MagazineName = "New magazine";
            MagazineIssue = Frequency.Yearly;
            ReleaseDate = new DateTime(1998, 3, 19);
            Circulation = 1;
            ArticleList = new Article[0];
        }

        public void AddArticles(params Article[] NewArticles)
        {
            int n = 0;
            if (ArticleList != null)
                n = ArticleList.Length;
            Article[] tmp = new Article[n + NewArticles.Length];
            int i = 0;
            if (ArticleList != null)
            {
                for (i = 0; i < ArticleList.Length; i++)
                    tmp[i] = ArticleList[i];
            }
            for (int j = 0; j < NewArticles.Length; j++)
            {
                tmp[i] = NewArticles[j];
                i++;
            }
            ArticleList = tmp;
        }

        public override string ToString()
        {
            string tmp = string.Format("Name of magazine: {0} How often release: {1} release date: {2} routine: {3} \nList of posts:\n", MagazineName, MagazineIssue, ReleaseDate, Circulation);
            for (int i = 0; i < ArticleList.Length; i++)
                tmp += string.Format("{0}\n", ArticleList[i]);
            return tmp;
        }

        public virtual string ToShortString()
        {
            return string.Format("Name of magazine : {0} How often release: {1} release date: {2} routine: {3} Average Rating post: {4}", MagazineName, MagazineIssue, ReleaseDate, Circulation, AverageRate);
        }

        public Magazine(string MagazineName, Frequency MagazineIssue, DateTime ReleaseDate, int Circulation)
        {
            this.MagazineName = MagazineName;
            this.MagazineIssue = MagazineIssue;
            this.ReleaseDate = ReleaseDate;
            this.Circulation = Circulation;
            ArticleList = new Article[0];
        }


        private void FreqIndexes()
        {
            Frequency tmp;
            for (tmp = Frequency.Weekly; tmp <= Frequency.Yearly; tmp++)
                Console.WriteLine("Name: " + tmp + "Inxde: " + (int)tmp);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool End = false;
            Magazine[] MagazineSet = new Magazine[0];
            while (true)
            {
                Console.Clear();
                MenuCreate(new string[] { "Add magazine ", "Brief info of magazine", "Value of indexer to see value of frequency", "Full info magazine", "Add post to magazine", "Compare time work with array", "exit" });
                switch (Console.ReadKey(true).Key)
                {
                    // add magazine
                    case ConsoleKey.D1:
                        Magazine[] tmp = new Magazine[MagazineSet.Length + 1];
                        for (int i = 0; i < MagazineSet.Length; i++)
                            tmp[i] = MagazineSet[i];
                        MagazineSet = tmp;
                        MagazineSet[MagazineSet.Length - 1] = MagazineCreate();
                        break;
                    // brief info get
                    case ConsoleKey.D2:
                        if (MagazineSet.Length > 0)
                            Console.WriteLine(MagazineSet[Chooser(MagazineSet)].ToShortString());
                        else
                            Console.Write("\nFirst Create magazine");
                        Console.ReadKey(true);
                        break;
                    // just see all enums with index
                    case ConsoleKey.D3:
                        FreqIndexes(true);
                        break;
                    // full info of existing magazine
                    case ConsoleKey.D4:
                        if (MagazineSet.Length > 0)
                            Console.WriteLine(MagazineSet[Chooser(MagazineSet)]);
                        else
                            Console.Write("\nFirst Create magazine");
                        Console.ReadKey(true);
                        break;
                    // add article to magazine
                    case ConsoleKey.D5:
                        if (MagazineSet.Length > 0)
                            MagazineSet[Chooser(MagazineSet)].AddArticles(ArticleAdd());
                        else
                            Console.Write("\nFirst Create magazine");
                        Console.ReadKey(true);
                        break;

                    // doing test in arrays
                    case ConsoleKey.D6:
                        SpeedTest();
                        break;
                    // exit
                    case ConsoleKey.D7:
                        End = true;
                        break;
                    default: break;
                }
                if (End)
                    break;
            }
        }

        // display all magazine with index
        static int Chooser(Magazine[] data)
        {
            Console.Clear();
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine((i + 1) + "| " + data[i].MagazineName);
            }
            Console.Write("Insert index magazine: ");
            int tmp = 0;
            while (!Int32.TryParse(Console.ReadLine(), out tmp) || tmp < 0 || tmp > data.Length)
                Console.Write("Error...\nInsert index magazine: ");
            return tmp - 1;
        }

        static void MenuCreate(string[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
                Console.WriteLine("{0})" + fields[i], (i + 1));
        }

        static Magazine MagazineCreate()
        {
            Console.Clear();
            Console.Write("Insert Name of magazine: ");
            string a = Console.ReadLine();
            Console.WriteLine("Insert frequency release: ");
            FreqIndexes(false);
            int d = -1;
            while (!Int32.TryParse(Console.ReadLine(), out d) || d < 1 || d > 3)
                Console.WriteLine("invalid input...\nInsert frequency release: ");
            Frequency b = (Frequency)d;
            Console.WriteLine("Insert date release yyyy.mm.dd: ");
            string tmps = Console.ReadLine();
            DateTime c = new DateTime(Convert.ToInt32(tmps.Split('.')[0]), Convert.ToInt32(tmps.Split('.')[1]), Convert.ToInt32(tmps.Split('.')[2]));
            //тираж
            Console.Write("Insert routine: ");
            while (!Int32.TryParse(Console.ReadLine(), out d) || d < 1)
                Console.WriteLine("Error...\nInsert circulation: ");
            Magazine MyMagazine = new Magazine(a, b, c, d);
            Console.Write("Insert number of post: ");
            while (!Int32.TryParse(Console.ReadLine(), out d) || d < 1)
                Console.Write("Error...\nInsert number of post: ");
            Article[] tmp = new Article[d];
            for (int i = 0; i < d; i++)
            {
                Console.WriteLine("Post " + (i + 1));
                tmp[i] = ArticleCreate();
            }
            MyMagazine.AddArticles(tmp);
            return MyMagazine;
        }

        static Article[] ArticleAdd()
        {
            Console.Clear();
            Console.Write("Insert number of adding Article: ");
            int tmp = 0;
            while (!Int32.TryParse(Console.ReadLine(), out tmp) || tmp < 1)
                Console.Write("Error...\nInsert number of adding Article: ");
            Article[] ArtList = new Article[tmp];
            for (int i = 0; i < tmp; i++)
                ArtList[i] = ArticleCreate();
            return ArtList;
        }

        static Article ArticleCreate()
        {
            Console.Write("Insert Article Name: ");
            string a = Console.ReadLine();
            double tmp = 0;
            Console.Write("Insert rating article: ");
            while (!Double.TryParse(Console.ReadLine(), out tmp) || tmp < 0)
                Console.Write("Invalid input...\nInsert rating article: ");
            Console.Write("Insert name of Author: ");
            string b = Console.ReadLine();
            Console.Write("Insert last name of Author: ");
            string c = Console.ReadLine();
            Console.Write("Insert birth day of author dd.mm.yyyy: ");
            string tmps = Console.ReadLine();
            DateTime d = new DateTime(Convert.ToInt32(tmps.Split('.')[2]), Convert.ToInt32(tmps.Split('.')[1]), Convert.ToInt32(tmps.Split('.')[0]));
            Person e = new Person(b, c, d);
            Article MyArticle = new Article(e, a, tmp);
            return MyArticle;
        }

        static void FreqIndexes(bool flag)
        {
            Frequency tmp;
            for (tmp = Frequency.Weekly; tmp <= Frequency.Yearly; tmp++)
                Console.WriteLine("Name: " + tmp + "Index: " + (int)tmp);
            if (flag)
            {
                Console.Write("Enter to continue");
                Console.ReadKey(true);
            }
        }

        static void SpeedTest()
        {
            Console.Clear();
            Console.WriteLine("Insert number row and colomn with space:");
            string tmp = Console.ReadLine();
            int r = Int16.Parse(tmp.Split(' ')[0]);
            int c = Int16.Parse(tmp.Split(' ')[1]);
            Article[] OneDisArr = new Article[r * c];
            Article[,] TwoDisArr = new Article[r, c];
            Article[][] StepArr = new Article[r][];

            for (int i = 0; i < r; i++)
            {
                StepArr[i] = new Article[c];
                for (int j = 0; j < c; j++)
                {
                    TwoDisArr[i, j] = new Article();
                    StepArr[i][j] = new Article();
                }
            }
            for (int i = 0; i < r * c; i++)
                OneDisArr[i] = new Article();

            // one dimension array
            int Stime = Environment.TickCount;
            for (int i = 0; i < r * c; i++)
                OneDisArr[i].ArticleName = "None";
            int Etime = Environment.TickCount;
            int ODAtime = Etime - Stime;

            // two dimensional array
            Stime = Environment.TickCount;
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    TwoDisArr[i, j].ArticleName = "None";
            Etime = Environment.TickCount;
            int TDAtime = Etime - Stime;

            // jagged array
            Stime = Environment.TickCount;
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    StepArr[i][j].ArticleName = "None";
            Etime = Environment.TickCount;
            int SSAtime = Etime - Stime;

            //Время, затраченное каждым из массивов
            Console.WriteLine("Time on every array: ");
            Console.WriteLine("One dimensional: {0}\nTwo dimensional: {1}\nJagged array: {2}", ODAtime, TDAtime, SSAtime);
            Console.Write("Enter to continue");
            Console.ReadKey(true);
        }
    }
}
