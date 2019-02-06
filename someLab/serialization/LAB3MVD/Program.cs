using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3MVD
{
    [Serializable]
    public class Player
    {
        private string _fName, _sName;
        private int _fullYears;
        private string _position;
        private string _nation;
        private int _growth;
        private int _weight;

        public Player(){ }

        public Player(bool token)
        {
            if(token)
            {
                fName = null;
                sName = null;
                position = null;
                nation = null;
                fullYears = -1;
                growth = -1;
                weight = -1;
            }
            else
            {
                fName = "";
                sName = "";
                position = "";
                nation = "";
                fullYears = 0;
                growth = 0;
                weight = 0;
            }
        }

        public string fName { get { return _fName; }
            set
            {
                if (value != null)
                    _fName = value;
                else
                {
                    Console.Write("Введите имя игрока: ");
                    fName = Console.ReadLine();
                }
            }
        }
        public string sName { get { return _sName; }
            set
            {
                if (value != null)
                    _sName = value;
                else
                {
                    Console.Write("Введите фамилию игрока: ");
                    sName = Console.ReadLine();
                }
            }
        }
        public string position { get { return _position; }
            set
            {
                if (value != null)
                    _position = value;
                else
                {
                    Console.Write("Введите позицию игрока: ");
                    position = Console.ReadLine();
                }
            }
        }
        public string nation { get { return _nation; }
            set
            {
                if (value != null)
                    _nation = value;
                else
                {
                    Console.Write("Введите национальность игрока: ");
                    nation = Console.ReadLine();
                }
            }
        }
        public int fullYears { get { return _fullYears; }
            set
            {
                if (value > -1)
                    _fullYears = value;
                else
                {
                    Console.Write("Введите возраст игрока: ");
                    while (!Int32.TryParse(Console.ReadLine(), out _fullYears))
                        Console.Write("Ошибочный ввод...\nВведите возраст игрока: ");
                }
            }
        }
        public int growth { get { return _growth; }
            set
            {
                if (value > -1)
                    _growth = value;
                else
                {
                    Console.Write("Введите рост игрока: ");
                    while (!Int32.TryParse(Console.ReadLine(), out _growth))
                        Console.Write("Ошибочный ввод...\nВведите рост игрока: ");
                }
            }
        }
        public int weight { get { return _weight; }
            set
            {
                if (value > -1)
                    _weight = value;
                else
                {
                    Console.Write("Введите вес игрока: ");
                    while (!Int32.TryParse(Console.ReadLine(), out _weight))
                        Console.Write("Ошибочный ввод...\nВведите вес игрока: ");
                }
            }
        }

        public bool LookingForPlayer(string name)
        {
            if (_fName.IndexOf(name) != -1 || _sName.IndexOf(name) != -1 || (_fName + " " + _sName).IndexOf(name) != -1 || (_sName + " " + _fName).IndexOf(name) != -1)
                return true;
            else
                return false;
        }

        public string playerData { get { return string.Format("Имя: {0} Фамилия: {1} Национальность: {2} Позиция: {3} Возраст: {4} Рост: {5} Вес: {6}", fName, sName, nation, position, fullYears, growth, weight); } }

        public string output { get { return string.Format("P|{0}|{1}|{2}|{3}|{4}|{5}|{6}", fName, sName, fullYears, position, nation, growth, weight); } }
    }

    [Serializable]
    public class Club
    {
        public Player[] _playerSet;
        private string _fullName;
        private int _foundYear;
        private int _playersNum;
        private string _stadium;
        private double _budget;

        public Club(int n)
        {
            _playerSet = new Player[n];
            playersNum = n;
        }

        public Club()
        {
            //fullName = null;
            //foundYear = -1;
            //playersNum = -1;
            //stadium = null;
            //budget = -1;
            //for (int i = 0; i < playersNum; i++)
            //    this[i] = new Player(true);
        }

        public string fullName{get { return _fullName; }
            set
            {
                if (value != null)
                    _fullName = value;
                else
                {
                    Console.Write("Введите название клуба: ");
                    fullName = Console.ReadLine();
                }
            }
        }
        public string stadium{ get { return _stadium; }
            set
            {
                if (value != null)
                    _stadium = value;
                else
                {
                    Console.Write("Введите название стадиона: ");
                    stadium = Console.ReadLine();
                }
            }
        }
        public int foundYear{ get { return _foundYear; }
            set
            {
                if (value > -1)
                    _foundYear = value;
                else
                {
                    Console.Write("Введите год основания: ");
                    while (!Int32.TryParse(Console.ReadLine(), out _foundYear))
                        Console.Write("Ошибочный ввод...\nВведите год основания: ");
                }
            }
        }
        public double budget { get { return _budget; }
            set
            {
                if (value > 0)
                    _budget = value;
                else
                {
                    Console.Write("Введите бюджет: ");
                    while (!Double.TryParse(Console.ReadLine(), out _budget))
                        Console.Write("Ошибочный ввод...\nВведите бюджет: ");
                }
            }
        }
        public int playersNum { get { return _playersNum; }
            set
            {
                if (value > -1)
                    _playersNum = value;
                else
                {
                    Console.Write("Введите кол-во игроков: ");
                    while ((!Int32.TryParse(Console.ReadLine(), out _playersNum) || !(_playersNum > 0)))
                        Console.Write("Ошибочный ввод...\nВведите кол-во игроков: ");
                }
            }
        }

        public Player this[int i] { get { return _playerSet[i]; } set { _playerSet[i] = value; } }

        public bool LookingForClub(int pNum)
        {
            if (pNum == playersNum)
                return true;
            else
                return false;
        }

        public string clubData { get { return string.Format("Название клуба: {0} Год основания: {1} Стадион: {2} Бюджет: {3} Кол-во игроков: {4}", fullName, foundYear, stadium, budget, playersNum); } }

        public string output { get { return string.Format("C|{0}|{1}|{2}|{3}|{4}", playersNum, foundYear, fullName, stadium, budget); } }
    }

    [Serializable]
    public class League
    {
        public Club[] _clubs;
        private string _name;
        private int _foundYear;
        private int _teamNum;
        private string _country;

        public League()
        {
            //name = null;
            //foundYear = -1;
            //teamNum = -1;
            //country = null;
            //_clubs = new Club[teamNum];
            //for (int i = 0; i < teamNum; i++)
            //    this[i] = new Club();
        }

        public League(int n)
        {
            teamNum = n;
            _clubs = new Club[teamNum];
        }

        public string name { get { return _name; }
            set
            {
                if (value != null)
                    _name = value;
                else
                {
                    Console.Write("Введите название лиги: ");
                    name = Console.ReadLine();
                }
            }
        }
        public string country { get { return _country; }
            set
            {
                if (value != null)
                    _country = value;
                else
                {
                    Console.Write("Введите название страны: ");
                    _country = Console.ReadLine();
                }
            }
        }
        public int foundYear { get { return _foundYear; }
            set
            {
                if (value > -1)
                    _foundYear = value;
                else
                {
                    Console.Write("Введите год основания: ");
                    while (!Int32.TryParse(Console.ReadLine(), out _foundYear))
                        Console.Write("Ошибочный ввод...\nВведите год основания: ");
                }
            }
        }
        public int teamNum { get { return _teamNum; }
            set
            {
                if (value > -1)
                    _teamNum = value;
                else
                {
                    Console.Write("Введите кол-во команд: ");
                    while ((!Int32.TryParse(Console.ReadLine(), out _teamNum) || !(_teamNum > 0)))
                        Console.Write("Ошибочный ввод...\nВведите кол-во команд: ");
                }
            }
        }

        public Club this[int i] { get { return _clubs[i]; } set { _clubs[i] = value; } }

        public string leagueData { get { return string.Format("Название лиги: {0} Год основания: {1} Кол-во команд: {2} Страна:{3}", name, foundYear, teamNum, country); } }

        public string output { get { return string.Format("C|{0}|{1}|{2}|{3}", teamNum, foundYear, name, country); } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            League[] Base = new League[0];
            bool Error = false;
            while (true)
            {
                Error = false;
                Console.Clear();
                MenuCreate(new string[] { "Открыть готовую базу", "Десериализация", "Создать новую базу" });
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Error = BaseOpen(out Base);
                        break;
                    case ConsoleKey.D2:
                        DeSerialization(out Base);
                        break;
                    case ConsoleKey.D3:
                        break;
                    default:
                        Error = true;
                        break;
                }
                if (!Error)
                    break;
            }
            BaseWork(Base);
        }

        static void BaseWork(League[] Base)
        {
            bool Exit = false;
            while (true)
            {
                Console.Clear();
                MenuCreate(new string[] { "Вывести данные на экран",
                    "Поиск игрока по имени", "Поиск клуба по кол-ву игроков", "Изменить поле", "Добавить поле", "Удалить поле", "Сохранить изменения","Сериализация", "Завершение работы" });
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        BasePrint(Base);
                        break;
                    case ConsoleKey.D2:
                        PlayerSearch(Base);
                        break;
                    case ConsoleKey.D3:
                        ClubSearch(Base);
                        break;
                    case ConsoleKey.D4:
                        Base = FieldWork(Base, "изменения");
                        break;
                    case ConsoleKey.D5:
                        Base = FieldWork(Base, "добавления");
                        break;
                    case ConsoleKey.D6:
                        Base = FieldWork(Base, "удаления");
                        break;
                    case ConsoleKey.D7:
                        BaseSave(Base);
                        break;
                    case ConsoleKey.D8:
                        Serialization(Base);
                        break;
                    case ConsoleKey.D9:
                        Exit = true;
                        break;
                    default:
                        break;
                }
                if (Exit)
                    break;
            }
        }

        static void MenuCreate(string[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
                Console.WriteLine("{0})" + fields[i], (i + 1));
        }

        static bool BaseOpen(out League[] LeagueSet)
        {
            Console.Clear();
            Console.WriteLine("Введите полный путь к файлу базы данных:");
            string Way = Console.ReadLine();
            try
            {
                StreamReader Reader = new StreamReader(new FileStream(@Way, FileMode.Open, FileAccess.Read));
                string[] League = Reader.ReadToEnd().Split('E');
                Reader.Close();
                LeagueSet = new League[League.Length - 1];
                for (int i = 0; i < League.Length - 1; i++)
                    LeagueSet[i] = StringBaseLeagueInput(League[i].Split('\n'));
                return false;
            }
            catch
            {
                Console.WriteLine("Ошибка доступа к файлу базы\nДля продолжения нажмите любую клавишу...");
                LeagueSet = new League[0];
                Console.ReadKey(true);
                return true;
            }
        }

        static League StringBaseLeagueInput(string[] info)
        {
            string[] tmpL = info[0].Split('|');
            League tmp = new League(Convert.ToInt32(tmpL[1]));
            for (int i = 0; i < Convert.ToInt32(tmpL[1]); i++)
            {
                string[] tmpC = info[1 + i].Split('|');
                tmp[i] = new Club(Convert.ToInt32(tmpC[1]));
                for (int j = 0; j < Convert.ToInt32(tmpC[1]); j++)
                {
                    tmp[i][j] = new Player(false);
                    string[] tmpP = info[1 + Convert.ToInt32(tmpL[1]) + j].Split('|');
                    tmp[i][j].fName = tmpP[1];
                    tmp[i][j].sName = tmpP[2];
                    tmp[i][j].fullYears = int.Parse(tmpP[3]);
                    tmp[i][j].position = tmpP[4];
                    tmp[i][j].nation = tmpP[5];
                    tmp[i][j].growth = int.Parse(tmpP[6]);
                    tmp[i][j].weight = int.Parse(tmpP[7]);
                }
                tmp[i].foundYear = int.Parse(tmpC[2]);
                tmp[i].fullName = tmpC[3];
                tmp[i].stadium = tmpC[4];
                tmp[i].budget = double.Parse(tmpC[5]);
            }
            tmp.foundYear = int.Parse(tmpL[2]);
            tmp.name = tmpL[3];
            tmp.country = tmpL[4];
            return tmp;
        }

        static void BasePrint(League[] db)
        {
            Console.Clear();
            if (db.Length > 0)
            {
                for (int i = 0; i < db.Length; i++)
                {
                    Console.WriteLine((i + 1) + "| " + db[i].leagueData);
                    for (int j = 0; j < db[i].teamNum; j++)
                    {
                        Console.WriteLine("\t" + (j + 1) + "| " + db[i][j].clubData);
                        for (int k = 0; k < db[i][j].playersNum; k++)
                            Console.WriteLine("\t\t" + (k + 1) + "| " + db[i][j][k].playerData);
                    }
                }
                Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Элементы не найдены\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey(true);
            }
        }

        static void PlayerSearch(League[] db)
        {
            Console.Clear();
            Console.Write("Имя игрока: ");
            string tmp = Console.ReadLine();
            Console.WriteLine("Результаты поиска:");
            for (int i = 0; i < db.Length; i++)
                for (int j = 0; j < db[i].teamNum; j++)
                    for (int k = 0; k < db[i][j].playersNum; k++)
                        if (db[i][j][k].LookingForPlayer(tmp))
                            Console.WriteLine("Лига: " + db[i].name + "\nКлуб: " + db[i][j].fullName + "\n" + db[i][j][k].playerData);
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey(true);
        }

        static void ClubSearch(League[] db)
        {
            Console.Clear();
            Console.Write("Кол-во игроков: ");
            int tmp = 0;
            while (!Int32.TryParse(Console.ReadLine(), out tmp))
                Console.WriteLine("Ошибочный ввод\nКол-во игроков: ");
            Console.WriteLine("Результаты поиска:");
            for (int i = 0; i < db.Length; i++)
                for (int j = 0; j < db[i].teamNum; j++)
                    if (db[i][j].LookingForClub(tmp))
                        Console.WriteLine("Лига: " + db[i].name + "\n" + db[i][j].clubData);
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey(true);
        }

        static League[] FieldWork(League[] db, string action)
        {
            Console.Clear();
            bool Exit = false;
            int a = -1, b = -1, c = -1;
            while (true)
            {
                Exit = true;
                Console.Clear();
                Console.WriteLine("Укажите тип поля для " + action);
                MenuCreate(new string[] { "Лига", "Клуб", "Игрок" });
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        if (action == "изменения" || action == "удаления")
                            a = Choose(db);
                        break;
                    case ConsoleKey.D2:
                        a = Choose(db);
                        if (action == "изменения" || action == "удаления")
                            b = Choose(db[a]);
                        break;
                    case ConsoleKey.D3:
                        a = Choose(db);
                        b = Choose(db[a]);
                        if (action == "изменения" || action == "удаления")
                            c = Choose(db[a][b]);
                        break;
                    default:
                        Exit = false;
                        break;
                }
                if (Exit)
                    break;
            }
            if (action == "изменения" || action == "удаления")
            {
                if (c != -1)
                {
                    if (action == "изменения")
                        db[a][b][c] = new Player(true);
                    else
                    {
                        if (action == "удаления")
                        {
                            if (db[a][b].playersNum > 1)
                            {
                                Club tmp = new Club(db[a][b].playersNum - 1);
                                int k = 0;
                                for (int i = 0; i < db[a][b].playersNum; i++)
                                {
                                    if (i != c)
                                    {
                                        tmp[k] = db[a][b][i];
                                        k++;
                                    }
                                }
                                tmp.playersNum = db[a][b].playersNum - 1;
                                tmp.foundYear = db[a][b].foundYear;
                                tmp.fullName = db[a][b].fullName;
                                tmp.budget = db[a][b].budget;
                                tmp.stadium = db[a][b].stadium;
                                db[a][b] = tmp;
                            }
                            else
                            {
                                Console.WriteLine("Необходимо наличие по крайней мере 2х элементов...");
                            }
                        }
                    }
                }
                else
                {
                    if (b != -1)
                    {
                        if (action == "изменения")
                            db[a][b] = new Club();
                        else
                        {
                            if (action == "удаления")
                            {
                                if (db[a].teamNum>1)
                                {
                                    League tmp = new League(db[a].teamNum - 1);
                                    int k = 0;
                                    for (int i = 0; i < db[a].teamNum; i++)
                                    {
                                        if (i != b)
                                        {
                                            tmp[k] = db[a][i];
                                            k++;
                                        }
                                    }
                                    tmp.teamNum = db[a].teamNum - 1;
                                    tmp.name = db[a].name;
                                    tmp.foundYear = db[a].foundYear;
                                    tmp.country = db[a].country;
                                    db[a] = tmp;
                                }
                                else
                                {
                                    Console.WriteLine("Необходимо наличие по крайней мере 2х элементов...");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (action == "изменения")
                            db[a] = new League();
                        else
                        {
                            if (action == "удаления")
                            {
                                if (db.Length > 1)
                                {
                                    League[] tmp = new League[db.Length - 1];
                                    int k = 0;
                                    for (int i = 0; i < db.Length; i++)
                                    {
                                        if (i != a)
                                        {
                                            tmp[i] = db[i];
                                            k++;
                                        }
                                    }
                                    db = tmp;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Необходимо наличие по крайней мере 2х элементов...");
                            }
                        }
                    }
                }
            }
            else
            {
                if (b != -1)
                {
                    Club tmp = new Club(db[a][b].playersNum + 1);
                    for (int i = 0; i < db[a][b].playersNum; i++)
                        tmp[i] = db[a][b][i];
                    tmp[b + 1] = new Player(true);
                    tmp.foundYear = db[a][b].foundYear;
                    tmp.fullName = db[a][b].fullName;
                    tmp.budget = db[a][b].budget;
                    tmp.stadium = db[a][b].stadium;
                    tmp.playersNum = db[a][b].playersNum + 1;
                    db[a][b] = tmp;
                }
                else
                {
                    if (a != -1)
                    {

                        League tmp = new League(db[a].teamNum + 1);
                        for (int i = 0; i < db[a].teamNum; i++)
                            tmp[i] = db[a][i];
                        tmp.country = db[a].country;
                        tmp.foundYear = db[a].foundYear;
                        tmp.name = db[a].name;
                        tmp.teamNum = db[a].teamNum + 1;
                        tmp[b + 1] = new Club();

                    }
                    else
                    {
                        League[] tmp = new League[db.Length + 1];
                        for (int i = 0; i < db.Length; i++)
                            tmp[i] = db[i];
                        tmp[db.Length] = new League();
                        db = tmp;
                    }
                }
            }
            
            return db;
        }

        static int Choose(League[] db)
        {
            Console.Clear();
            int result = -1;
            for (int i = 0; i < db.Length; i++)
                Console.WriteLine((i + 1) + "|" + db[i].leagueData);
            Console.Write("\nВведите номер лиги: ");
            while (!(Int32.TryParse(Console.ReadLine(), out result)) || !(result > 0 && result < db.Length + 1))
                Console.Write("Ошибочный ввод...\nВведите номер лиги: ");
            return result - 1;
        }

        static int Choose(League db)
        {
            Console.Clear();
            int result = -1;
            for (int i = 0; i < db.teamNum; i++)
                Console.WriteLine((i + 1) + "|" + db[i].clubData);
            Console.Write("\nВведите номер клуба: ");
            while ((!Int32.TryParse(Console.ReadLine(), out result)) || !(result > 0 && result < db.teamNum + 1))
                Console.Write("Ошибочный ввод...\nВведите номер клуба: ");
            return result - 1;
        }

        static int Choose(Club db)
        {
            Console.Clear();
            int result = -1;
            for (int i = 0; i < db.playersNum; i++)
                Console.WriteLine((i + 1) + "|" + db[i].playerData);
            Console.Write("\nВведите номер игрока: ");
            while ((!Int32.TryParse(Console.ReadLine(), out result)) && !(result > 0 && result < db.playersNum + 1))
                Console.Write("Ошибочный ввод...\nВведите номер игрока: ");
            return result - 1;
        }

        static void BaseSave(League[] db)
        {
            Console.Clear();
            Console.WriteLine("Введите полный путь к папке для сохранения базы данных:");
            string Way = Console.ReadLine() + "Football.xdb";
            try
            {
                StreamWriter Writer = new StreamWriter(new FileStream(@Way, FileMode.Create, FileAccess.Write));
                for (int i = 0; i < db.Length; i++)
                {
                    Writer.WriteLine(db[i].output);
                    for (int j = 0; j < db[i].teamNum; j++)
                    {
                        Writer.WriteLine(db[i][j].output);
                        for (int k = 0; k < db[i][j].playersNum; k++)
                            Writer.WriteLine(db[i][j][k].output);
                    }
                    Writer.WriteLine("E");
                }
                Writer.Close();
            }
            catch
            {
                Console.WriteLine("Ошибка доступа к файлу базы\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey(true);
            }
        }

        static void Serialization(League[] target)
        {
            bool Exit = false;
            FileStream s = File.Open("me.dat", FileMode.Create, FileAccess.Write);
            while (!Exit)
            {
                Exit = true;
                Console.Clear();
                MenuCreate(new string[] { "Binary", "Soap", "XML"});
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(s, target);
                        s.Close();
                        break;
                    case ConsoleKey.D2:
                        SoapFormatter sf = new SoapFormatter();
                        sf.Serialize(s, target);
                        s.Close();
                        break;
                    case ConsoleKey.D3:
                        XmlSerializer xmls = new XmlSerializer(typeof(League[]), new Type[] { typeof(Club), typeof(Player)});
                        xmls.Serialize(s, target);
                        s.Close();
                        break;
                    default:
                        Exit = false;
                        break;
                }
            }
        }

        static void DeSerialization(out League[] tg)
        {
            tg = null;
            object t=null;
            bool Exit = false;
            FileStream s = File.Open("me.dat", FileMode.Open, FileAccess.Read);
            while (!Exit)
            {
                Exit = true;
                Console.Clear();
                MenuCreate(new string[] { "Binary", "Soap", "XML" });
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        BinaryFormatter bf = new BinaryFormatter();
                        t = bf.Deserialize(s);
                        
                        break;
                    case ConsoleKey.D2:
                        SoapFormatter sf = new SoapFormatter();
                        t = sf.Deserialize(s);
                        s.Close();
                        break;
                    case ConsoleKey.D3:
                        XmlSerializer xmls = new XmlSerializer(typeof(League[]));
                        t = xmls.Deserialize(s);
                        s.Close();
                        break;
                    default:
                        Exit = false;
                        break;
                }
            }
            s.Close();
            tg = t as League[];
            if (tg == null)
            {
                tg = new League[0];
            }
        }
    }
}
