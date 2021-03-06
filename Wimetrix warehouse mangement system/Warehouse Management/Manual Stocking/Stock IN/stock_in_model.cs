﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_IN
{
    class stock_in_model
    {
        public bool Select { get; set; }
        public string Order { get; set; }
        public string Vendor { get; set; }
        public string Fabric_Lot { get; set; }
        public string Fabric_Type { get; set; }
        public string Roll_ID { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
        public string Card_Status { get; set; }

        public stock_in_model(bool Select, String Order, String Roll_ID, String Color, String Weight, String vendor, String fabric_lot, String fabric_type, String card_status)
        {
            this.Select = Select;
            this.Order = Order;
            this.Roll_ID = Roll_ID;
            this.Color = Color;
            this.Weight = Weight;
            this.Vendor = vendor;
            this.Fabric_Lot = fabric_lot;
            this.Fabric_Type = fabric_type;
            this.Card_Status = card_status;
        }
    }
}
