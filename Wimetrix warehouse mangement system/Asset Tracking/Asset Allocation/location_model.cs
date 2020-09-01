using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Allocation
{
    class location_model
    {
        public String Location { get; set; }
        public String Description { get; set; }

        public location_model(String Location_id, String Description)
        {
            this.Location = Location_id;
            this.Description = Description;

        }
    }
}
