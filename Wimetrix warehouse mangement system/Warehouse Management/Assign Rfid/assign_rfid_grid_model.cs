using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Assign_Rfid
{
    class assign_rfid_grid_model
    {
        public string Order { get; set; }
        public string Roll_ID { get; set; }
        public string RFID { get; set; }
        public string Fabric { get; set; }
        public assign_rfid_grid_model( String Order, String Roll_id, String RFID, String Fabric )
        {          
            this.Roll_ID = Roll_id;
            this.Order = Order;
            this.RFID = RFID;
            this.Fabric = Fabric;
        }
    }
}
