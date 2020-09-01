using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel
{
    class uploaded_excel_model
    {
        public String Order { get; set; }
        public String Weight { get; set; }
        public String Fabric { get; set; }
        public String Packing_list_code { get; set; }
        public String Status { get; set; }

        public uploaded_excel_model(string order, string weight, string fabric, string packing_list_code, string status)
        {
            Order = order;
            Weight = weight;
            Fabric = fabric;
            Packing_list_code = packing_list_code;
            Status = status;
        }

        public String getStatus()
        {
            return this.Status;
        }
    }
}
