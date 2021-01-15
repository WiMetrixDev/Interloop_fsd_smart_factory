using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.view_Packing_List
{
    class packing_list_model

    {
    public  String ERP_Item_Code { get; set; }
        public String Internal_Order_No { get; set; }
        public String Customer_Name { get; set; }
        public String Vendor_Name { get; set; }
        public String Fabric_Type { get; set; }
        public String Yarn_Supplier { get; set; }
        public String Yarn_Lot_No { get; set; }
        public String Fabric_Lot_No { get; set; }
        public String Color_Code { get; set; }
        public String Weight { get; set; }
        public String Roll_ID { get; set; }
        public String GSM { get; set; }
        public String Goods_code { get; set; }
        public String IGP_Date { get; set; }
        public String IGP_No { get; set; }
        public String DCN { get; set; }
        public String supplier_code { get; set; }
        public String fabric_content { get; set; }

        public String supplier_roll_id { get; set; }
        public packing_list_model(String item_code,String order,String customer,String vendor,String fabric_type,String yarn_supplier,String yarn_lot,String fabric_lot,String color,String weight,String roll,String gsm,String goods_code,String IGP_date,String Igp_no,String dcn,String supplier_code, String fabric_content, String supplier_roll_id)
        {
            this.ERP_Item_Code = item_code;
            this.Internal_Order_No = order;
            this.Customer_Name = customer;
            this.Vendor_Name = vendor;
            this.Fabric_Type = fabric_type;
            this.Yarn_Supplier = yarn_supplier;
            this.Yarn_Lot_No = yarn_lot;
            this.Fabric_Lot_No = fabric_lot;
            this.Color_Code = color;
            this.Weight = weight;
            this.Roll_ID = roll;
            this.GSM = gsm;
            this.Goods_code = goods_code;
            this.IGP_Date = IGP_Date;
            this.IGP_No = Igp_no;
            this.DCN = dcn;
            this.supplier_code = supplier_code;
            this.fabric_content = fabric_content;
            this.supplier_roll_id = supplier_roll_id;


        }

    }
}
