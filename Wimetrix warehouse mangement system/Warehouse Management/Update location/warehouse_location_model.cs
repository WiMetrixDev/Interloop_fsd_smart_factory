using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Update_location
{
    class warehouse_location_model
    {
        public String location_id { get; set; }
        public String Description { get; set; }

        public warehouse_location_model(String Location_id, String Description)
        {
            this.location_id = Location_id;
            this.Description = Description;

        }

        public override string ToString()
        {
            return Description;
        }
    }
}
