using System;
using System.IO;
using GeoJSON;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TestMapArea
{

    public class Place
    {
        public int place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public int osm_id { get; set; }
        public string[] boundingbox { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }
        public string _class { get; set; }
        public string type { get; set; }
        public float importance { get; set; }
        public string icon { get; set; }
        public Geojson geojson { get; set; }
    }

    public class Geojson
    {
        public string type { get; set; }
        public double[][][] coordinates { get; set; }
    }

}
