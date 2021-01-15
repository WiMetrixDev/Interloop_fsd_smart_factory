using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel
{
    class upload_excel_model
    {
      public  String item_code { get; set; }
        public String item_description { get; set; }
        public String igp_date { get; set; }
        public String igp_no { get; set; }
        public String order_no { get; set; }
        public String customer_name { get; set; }
        public String customer_code { get; set; }
        public String dcn_no { get; set; }
        public String vendor_name { get; set; }
        public String fabric_type { get; set; }
        public String yarn_supplier { get; set; }
        public String yarn_no { get; set; }
        public String fabric_lot_no { get; set; }
        public String color_code { get; set; }
        public String gsm { get; set; }
        public String fabric_width { get; set; }
        public String weight { get; set; }
        public String pcs { get; set; }
        public String roll_identification { get; set; }
        public String transaction_type { get; set; }
        public String roll_id { get; set; }
        public String fabric_length { get; set; }
        public String goods_code { get; set; }
        public String supplier_lot { get; set; }
        public String fabric_content { get; set; }
        public String supplier_roll_id { get; set; }



        public upload_excel_model(string item_code, string item_description, string igp_date, string igp_no, string order_no, string customer_name, string customer_code, string dcn_no, string vendor_name, string fabric_type, string yarn_supplier, string yarn_no, string fabric_lot_no, string color_code, string gsm, string fabric_width, string weight, string pcs, string roll_identification, string transaction_type, string roll_id, string fabric_length, string goods_code, string supplier_lot, string fabric_content,String Supplier_roll_id)
        {
            this.item_code = item_code;
            this.item_description = item_description;
            this.igp_date = igp_date;
            this.igp_no = igp_no;
            this.order_no = order_no;
            this.customer_name = customer_name;
            this.customer_code = customer_code;
            this.dcn_no = dcn_no;
            this.vendor_name = vendor_name;
            this.fabric_type = fabric_type;
            this.yarn_supplier = yarn_supplier;
            this.yarn_no = yarn_no;
            this.fabric_lot_no = fabric_lot_no;
            this.color_code = color_code;
            this.gsm = gsm;
            this.fabric_width = fabric_width;
            this.weight = weight;
            this.pcs = pcs;
            this.roll_identification = roll_identification;
            this.transaction_type = transaction_type;
            this.roll_id = roll_id;
            this.fabric_length = fabric_length;
            this.goods_code = goods_code;
            this.supplier_lot = supplier_lot;
            this.fabric_content = fabric_content;
            this.supplier_roll_id = Supplier_roll_id;
        }
    }
}
