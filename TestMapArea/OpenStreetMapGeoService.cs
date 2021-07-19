using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Text;
using GeoJSON;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace TestMapArea
{
    class OpenStreetMapGeoService : IGeoService
    {
        public async Task<MapPlacePolygon> Search(string place)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.114 Safari/537.36");
            var result = await client.GetFromJsonAsync<List<Place>>("https://nominatim.openstreetmap.org/search?q=kazan&format=json&polygon_geojson=1");

            var mapPlacePolygon = new MapPlacePolygon
            {
                PlaceName = result[0].display_name,
                Polygon = result[0].geojson.coordinates.Select(coordinates => new Polygon
                {
                    Points = coordinates.Select(point => new Point
                    {
                        Longitude = point[0],
                        Latitude = point[1]
                    }).ToList()
                }).ToList()
            };
            return mapPlacePolygon;
        }
    }
}
