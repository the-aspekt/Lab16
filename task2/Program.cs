using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;


namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = string.Empty;
            using (StreamReader sr = new StreamReader("../../../items.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Item[] items = JsonSerializer.Deserialize<Item[]>(jsonString);
            Item maxPriceItem = items[0];
            foreach (Item i in items) 
            {
                if (i.Price>maxPriceItem.Price)
                {
                    maxPriceItem = i;
                }
            }
            Console.WriteLine($"Самый дорогой в подборке товар - это {maxPriceItem.Name} за номером {maxPriceItem.Articul} по цене {maxPriceItem.Price} евро за кг");
            Console.ReadKey();
        }
    }
}
