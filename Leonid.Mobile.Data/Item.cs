using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonid.Mobile.Data
{
    public class Item
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public List<Location> Locations { get; set; }
    }
}
