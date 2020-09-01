using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Track
{
    class asset_track_model
    {
        public String Machine { get; set; }
        public String Type { get; set; }
        public String Allocation { get; set; }
        public asset_track_model(String machine, String type,String allocation)
        {
            this.Machine = machine;
            this.Type = type;
            this.Allocation = allocation;
        }
    }
}
