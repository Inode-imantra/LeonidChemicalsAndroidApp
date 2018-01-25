using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonid.Mobile.DAL.Data
{
    public class Location
    {
        public int LocationId { get; set; }

        public int ItemId { get; set; }

        public string LocationName { get; set; }

        public int ItemCount { get; set; }
    }
}
