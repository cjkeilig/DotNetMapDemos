using MapsPlayground.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsPlayground.Data.Repositories
{
    public class ObjectToPlotSampleRepository : IObjectToPlotRepository
    {
        public IEnumerable<ObjectToPlot> GetObjectsToPlot(int howMany)
        {
            List<ObjectToPlot> result = new List<ObjectToPlot>();
            for (int i = 0; i < howMany; i++)
            {
                result.Add(new ObjectToPlot(i, "Name " + i, "Description " + i));
            }

            return result;
        }
    }
}
