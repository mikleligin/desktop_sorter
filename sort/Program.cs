using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Sort
{
    class Program
    {
        public static string pather(string name, string deskpath)
        {
            Directory.CreateDirectory($@"{deskpath}\сортированное2\{name.Substring(name.LastIndexOf("."))}");
            return $@"{deskpath}\сортированное2\{name.Substring(name.LastIndexOf("."))}\{name}";
        }

        //____________________________________________________
        //|
        //_______________
        static void Main(string[] args)
        {
            int count = 0;

            string deskpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Directory.CreateDirectory($@"{deskpath}\сортированное2");
            var dir = Directory.GetFiles($@"{deskpath}\сортированное2\");

            for (int i = 0; i < dir.Length; i++)
            {
                FileInfo inf = new FileInfo(dir[i]);
                if (inf.Name == "links.txt")
                {
                    count = 1;
                }


            }
            Directory.CreateDirectory($@"{deskpath}\сортированное2");
            Directory.CreateDirectory($@"{deskpath}\сортированное2\txt\");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добро пожаловать в DesktopSorter");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(deskpath);
            //string firstpath = $@"C:\Users\{userName}\Desktop";

            var directoryfiles = Directory.GetFiles(deskpath);
            Console.WriteLine(directoryfiles.Length);
            for (int i = 0; i < directoryfiles.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(directoryfiles[i]);
                string name = fileInfo.Name;


                try
                {

                    //Console.WriteLine("имя файла " + directoryfiles[i]);

                    //Console.WriteLine(pather(name, deskpath));
                    fileInfo.MoveTo(pather(name, deskpath));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Moved in ---> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(pather((name), deskpath));

                }
                catch (Exception)
                {

                    Console.WriteLine(name);
                    int indexofname = fileInfo.Name.IndexOf(".");
                    string last = name.Substring(name.LastIndexOf("."));
                    Random random = new Random();
                    int x = random.Next(0, 1000000);
                    //Console.WriteLine($"{name + name_of_file + $"{x}" + last}");
                    //Console.WriteLine($"{name_of_file + $"{x}" + last}");
                    Console.WriteLine("Moved in ---> " + pather((name + $"{x}" + last), deskpath));

                    fileInfo.MoveTo(pather((name + $"{x}" + last), deskpath));
                }

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Рабочий стол отсортирован!");

        }
    }
}
