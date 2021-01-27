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
            //Console.WriteLine("Передан некорректный путь");
            string dirName = way; // Прописываем путь к корневой директории
            
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Папка по заданному адресу не существует");
            }

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(way);
                Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
                if (dirInfo.Exists)
                {

                }
            }
            /*try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(way);
            dirInfo.Delete(true); // Удаление со всем содержимым
            Console.WriteLine("Каталог удален");
        }*/
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}