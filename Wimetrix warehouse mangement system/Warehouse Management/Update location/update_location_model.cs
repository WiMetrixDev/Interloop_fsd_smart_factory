using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking
{
    class update_location_model
    {
        public bool   Select { get; set; }
        public string Order { get; set; }
        public string Vendor { get; set; }
        public string Fabric_Lot { get; set; }
        public string Fabric_Type { get; set; }
        public string Roll_ID { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
        public string Location { get; set; }
        public string Supplier_lot { get; set; }
        public update_location_model(bool select, string order, string vendor, string fabric_Lot, string fabric_Type, string roll_ID, string color, string weight, string location, string supplier_lot)
        {
            Select = select;
            Order = order;
            Vendor = vendor;
            Fabric_Lot = fabric_Lot;
            Fabric_Type = fabric_Type;
            Roll_ID = roll_ID;
            Color = color;
            Weight = weight;
            Location = location;
            Supplier_lot = supplier_lot;
        }
    }
}
