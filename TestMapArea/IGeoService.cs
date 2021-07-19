using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMapArea
{
    interface IGeoService
    {
        Task<MapPlacePolygon> Search(string place);
    }
}
