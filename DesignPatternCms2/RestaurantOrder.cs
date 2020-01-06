using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCms2
{
    class RestaurantOrder
    {
        public enum Status
        {
            Received,
            Started,
            ReadyForServing,
            Served
        };
        public Status OrderStatus { get; set; }
        public int TableNumber { get; set; }
        public string Servant { get; set; }
        public List<RestaurantOrderRow> OrderParts { get; set; }
    }

    class RestaurantOrderRow
    {
        public string Product { get; set; }
        public int Count { get; set; }
    }

}
