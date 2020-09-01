using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.Add_new_Assets
{
    class uploaded_asset_model
    {
       public  String Serial { get; set; }
        public String Machine_ID { get; set; }
        public String Machine_Type { get; set; }
        public String Model { get; set; }
        public String Brand { get; set; }
        public String IGP { get; set; }
        public  String Price { get; set; }
        public String Vendor { get; set; }
        public String Status { get; set; }

        public uploaded_asset_model(String serial,String machine_id,String machine_type,String model,String brand,String IGP,String price,String vendor,String status)
        {
            this.Serial = serial;
            this.Machine_ID = machine_id;
            this.Machine_Type = machine_type;
            this.Model = model;
            this.Brand = brand;
            this.IGP = IGP;
            this.Price = price;
            this.Vendor = vendor;
            this.Status = status;
        }
       

    }
}
