using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Allocation
{
    class asset_allocation_model
    {
        public bool Select { get; set; }
        public String Machine { get; set; }
        public String Type { get; set; }
        public String Location { get; set; }
        public String RFID { get; set; }

        public asset_allocation_model(String Machine, String Type,String Location,String RFID)
        {
            this.Select = false;
            this.Machine = Machine;
            this.Type = Type;
            this.Location = Location;
            this.RFID = RFID;
        }
    }
}
