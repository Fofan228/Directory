using System;
using System.IO;
namespace Exam
{
    class Program
    {
        public static string way;
        public static void DeleteFile(string name)
        {
            File.Delete(name);
        }
        public static void CreateFile(string name)
        {
            File.WriteAllText(name, "");
        }
        public static void UseCd(string name)
        {
            for (int i = 0; i < way.Length; i++)
            {
                if(name.Contains(way[i..(name.Length + i)]))
                {
                    way = way.Remove(i);
                }
            }
        }
        public static void UseCd()
        {
            for (int i = way.Length - 1; i >= 0; i--)
            {
                if (way[i] == '\\')
                {
                    way = way.Remove(i);
                    break;
                }
            }
        }
        public static void WriteTreatment(string command)
        {
            if (command == "cd:.")
            {
                UseCd();
            } 
            else if(command.Contains("cd:"))
            {
                string[] commandPath = command.Split(":");
                UseCd(commandPath[1]);
            }    
            else if (command.Contains("new:"))
            {
                string[] commandPath = command.Split(":");
                CreateFile(commandPath[1]);
            }
            else
            {
                string[] commandPath = command.Split(":");
                DeleteFile(commandPath[1]);
            }
        }
        public static void WritePath()
        {
            foreach (var file in Directory.GetFiles("."))
                Console.WriteLine(file);
        }
        static void Main(string[] args)
        {
            way = Environment.CurrentDirectory;
            while (true)
            {
                Console.WriteLine(way);
                WritePath();
                string input = Console.ReadLine();
                WriteTreatment(input);
            }
        }
    }
}
