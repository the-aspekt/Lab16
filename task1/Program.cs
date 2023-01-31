using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;


namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int amount = 5;
            int articul;
            string name = string.Empty;
            double price;
            Item[] items = new Item[amount];

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("Введите артикул товара");
                articul = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите имя товара");
                name = Console.ReadLine();
                Console.WriteLine("Введите стоимость товара");
                price = Convert.ToDouble(Console.ReadLine());
                items[i] = new Item() { Articul = articul, Name = name, Price = price };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(items, options);

            using (StreamWriter sr = new StreamWriter("../../../items.json"))
            {
                sr.WriteLine(jsonString);
            }


        }
    }
}
