using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Upload_Parts
{
    class parts_model
    {
        public String ID { get; set; }
        public String Item { get; set; }
        public String Name { get; set; }
        public String Organization { get; set; }
        public String UOM { get; set; }
        public String Quantity { get; set; }
        public String Location { get; set; }
        public parts_model(string part_id, string item, string part_name, string organization, string uOM, string part_quantity, string Location)
        {
            this.ID = part_id;
            Item = item;
            this.Name = part_name;
            Organization = organization;
            UOM = uOM;
            this.Quantity = part_quantity;
            this.Location = Location;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
