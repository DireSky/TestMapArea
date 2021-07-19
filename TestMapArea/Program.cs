using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Linq;
using System.Collections.Generic;

namespace TestMapArea
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var geoService = new OpenStreetMapGeoService();
            Console.WriteLine("Введите запрос:");
            string query = Console.ReadLine();
            Console.WriteLine("Введите количество точек:");
            int amountOfPoints = Convert.ToInt32(Console.ReadLine());
            var place = await geoService.Search(query);
            for(var i = 0; i<place.Polygon.Count; i++)
            {
                place.Polygon[i].Points = EveryNthElement(place.Polygon[i].Points, amountOfPoints);
            }
            var serializer = JsonSerializer.Serialize(place);
            using (FileStream PlaceJsonFile = new FileStream("place.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(PlaceJsonFile, place);
                Console.WriteLine("Done");
            }
        }

        static List<Point> EveryNthElement(List<Point> list, int n)
        {
            List<Point> result = new List<Point>();
            for (int i = 0; i < list.Count; i++)
            {
                if ((i % n) == 0)
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }

    }
}
