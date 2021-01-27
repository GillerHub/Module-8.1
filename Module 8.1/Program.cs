using System;
using System.IO;
namespace DirectoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCatalogs(); //   Вызов метода получения директорий
        }

        static void GetCatalogs()
        {
             
            Console.WriteLine("Введите путь: ");
            var way = Console.ReadLine();

            string dirName = way; // Прописываем путь к корневой директории
            
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs2 = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога
                string[] dirs1 = Directory.GetFiles(dirName, "*", SearchOption.AllDirectories);  // Получим все файлы корневого каталога
                string[] dirs = new string[dirs1.Length + dirs2.Length];
                dirs1.CopyTo(dirs, 0);
                dirs2.CopyTo(dirs, dirs1.Length);
                DateTime DT = DateTime.Now.Subtract(TimeSpan.FromMinutes(30));
                Console.WriteLine(DT.ToString());
                Console.WriteLine(DateTime.Now.ToString());
                foreach (string d in dirs) // Выведем их все
                { 
                    Console.WriteLine(d);
                    Console.WriteLine(Directory.GetLastAccessTime(d).ToString());
                    if (Directory.GetLastAccessTime(d) < DT)
                    {
                        if (d.Contains("F:/temp/d")) 
                        {
                            Directory.Delete(d, true);
                            Console.WriteLine("Файл удалён " +d);
                        } 
                        else Console.WriteLine("Вы пытаетесь удалить нужный файл " +d);
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Папка по заданному адресу не существует");
            }
            
        }
    }
}