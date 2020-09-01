using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Update_location
{
    class update_location_grid_model
    {
        public bool Select { get; set; }
        public string Roll_ID { get; set; }
        public string Order { get; set; }
        public string Fabric { get; set; }
        public string Location { get; set; }
        public update_location_grid_model(bool checkBox,String roll_id,String internal_order,String fabric_code,String Location)
        {
            this.Select       = checkBox;
            this.Roll_ID      = roll_id;
            this.Order        = internal_order;
            this.Fabric       = fabric_code;
            this.Location     = Location;
        }
    }
}
