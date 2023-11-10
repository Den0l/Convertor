using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Convertor
{
    internal class Program
    {
        static void Main()
        {
            string fPath;
            
            List<Human> humans = new List<Human>();
            
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine("Введите путь файла, который хотите открыть");
                Console.WriteLine("_____________________________________________________");
                fPath = Console.ReadLine();
                Console.Clear();

                ReadFile RF = new ReadFile();
                if (RF.FileExists(fPath))
                {
                    string extension = Path.GetExtension(fPath).ToLower();

                    if (extension == ".txt")
                    {
                        string text = RF.Read(fPath);
                        humans = RF.ReadText(text, humans);
                    }
                    else if (extension == ".json")
                    {
                        string json = RF.Read(fPath);
                        humans = RF.ReadJson(json, humans);
                    }
                    else if (extension == ".xml")
                    {
                        string xml = RF.Read(fPath);
                        humans = RF.ReadXml(xml, humans);
                    }
                    

                    DisplayHumans(humans);
                    Console.WriteLine("Нажмите F1 для сохранения файла или Escape для выхода.");
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }

                key = Console.ReadKey();
                if(key.Key == ConsoleKey.F1)
                {
                    fPath = Console.ReadLine();
                    string extension = Path.GetExtension(fPath).ToLower();

                    if (extension == ".txt")
                    {
                        RF.SaveText(fPath, humans);
                    }
                    else if (extension == ".json")
                    {
                        RF.SaveJson(fPath, humans);
                    }
                    else if (extension == ".xml")
                    {
                        RF.SaveXml(fPath, humans);
                    }
                    Console.WriteLine("Файл сохранен. \nДля продолжения нажмите любую клавишу или Escape для выходы");
                    key = Console.ReadKey();
                    if(key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    Console.Clear();
                }
                else
                {
                    break;
                }

            } while (key.Key != ConsoleKey.Escape);

            static void DisplayHumans(List<Human> humans)
            {
                if (humans.Count == 0)
                {
                    Console.WriteLine("Файл пуст.");
                }
                else
                {
                    foreach (var human in humans)
                    {
                        Console.WriteLine($"Имя: {human.name}, Страна: {human.country}, Возраст: {human.age}");
                    }
                }
            }
        }
    }
}
