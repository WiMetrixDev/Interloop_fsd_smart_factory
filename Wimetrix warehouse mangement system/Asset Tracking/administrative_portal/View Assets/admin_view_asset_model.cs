using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.View_Assets
{
    class admin_view_asset_model
    {
        public bool Select { get; set; }
        public String Good_id { get; set; }
        public String Machine { get; set; }
        public String Type { get; set; }
        public String Location { get; set; }
        public String Price { get; set; }
        public String RFID { get; set; }
        public String Country {get; set; }
        public String Sub_Type { get; set; }
        public String Model{ get; set; }
        public String Vendor{ get; set; }
        public String Supplier  { get; set; }
        public String Brand { get; set; }
        public String Module { get; set; }
        public String igp_date { get; set; }
        public String manufacturing_year { get; set; }
        public String installation_date { get; set; }

        public String Line { get; set; }
        public admin_view_asset_model(string good_id, string machine, string type, string location, string price, string rFID, string country, string sub_Type, string model, string vendor, string supplier, string brand, string module,String igp_date, String manufacturing_year ,String installation_date,String line)
        {
            this.Select = false; 
            this.Good_id = good_id;
            this.Machine = machine;
            this.Type = type;
            this.Location = location;
            this.Price = price;
            this.RFID = rFID;
            this.Country = country;
            this.Sub_Type = sub_Type;
            this.Model = model;
            this.Vendor = vendor;
            this.Supplier = supplier;
            this.Brand = brand;
            this.Module = module;
            this.igp_date = igp_date;
            this.manufacturing_year = manufacturing_year;
            this.installation_date = installation_date;
            this.Line = line;
        }
    }
}
