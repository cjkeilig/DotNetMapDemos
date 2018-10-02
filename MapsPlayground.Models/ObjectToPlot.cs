using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsPlayground.Data
{
    public class ObjectToPlot
    {

        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public ObjectToPlot(Int32 Id, String Name, String Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }
    }
}
