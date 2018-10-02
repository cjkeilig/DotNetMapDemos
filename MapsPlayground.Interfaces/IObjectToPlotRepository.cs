using MapsPlayground.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsPlayground.Interfaces
{
    public interface IObjectToPlotRepository
    {
        IEnumerable<ObjectToPlot> GetObjectsToPlot(Int32 howMany);
    }
}
