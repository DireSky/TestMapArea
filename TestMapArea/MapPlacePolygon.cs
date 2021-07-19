using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMapArea
{
    class MapPlacePolygon
    {
        public string PlaceName { get; set; }

        public List<Polygon> Polygon { get; set; }

    }
    public class Polygon
    {
        public List<Point> Points { get; set; }
    }

    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
